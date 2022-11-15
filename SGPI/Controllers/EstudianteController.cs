using Microsoft.AspNetCore.Mvc;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class EstudianteController : Controller
    {
        SGPIDBContext context = new SGPIDBContext();
        public IActionResult ModificarEstudiante(int ? Idusuario)
        {

            Usuario usuario = context.Usuarios.Find(Idusuario);

            if (usuario != null)
            {
                ViewBag.genero = context.Generos.ToList();
                ViewBag.programa = context.Programas.ToList();
                ViewBag.tipodocumento = context.Documentos.ToList();
                return View(usuario);
            }
            else
            {
                return Redirect("/Estudiante/ModificarEstudiante/?Idusuario");
            }
        }
        [HttpPost]
        public IActionResult ModificarEstudiante(Usuario usuario)
        {
            var usuarioActualizar = context.Usuarios
               .Where(consulta => consulta.IdUsuario == usuario.IdUsuario).FirstOrDefault();


            usuarioActualizar.NumeroDocumento = usuario.NumeroDocumento;
            usuarioActualizar.PrimerNombre = usuario.PrimerNombre;
            usuarioActualizar.PrimerNombre = usuario.SegundoNombre;
            usuarioActualizar.PrimerApellido = usuario.PrimerApellido;
            usuarioActualizar.IdGenero = usuario.IdGenero;
            usuarioActualizar.Email = usuario.Email;
            usuarioActualizar.IdDocumento = usuario.IdDocumento;
            usuarioActualizar.IdPrograma = usuario.IdPrograma;

            ViewBag.mensaje = "Se ha actualizado con exito";
            context.Update(usuarioActualizar);
            context.SaveChanges();

            return Redirect("/Estudiante/ModificarEstudiante/?IdUsuario=" + usuarioActualizar.IdUsuario);
        }

        public IActionResult PagosEstudiante()
        {
            return View();
        }

        [HttpPost]

        public IActionResult PagosEstudiante(Pago usuario)
        {
            usuario.Estado = true;
            context.Pagos.Add(usuario);
            context.SaveChanges();
            ViewBag.mensaje = "Pago enviado";

            return View();


        }

    }
}
