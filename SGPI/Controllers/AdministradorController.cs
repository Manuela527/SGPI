using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        SGPIDBContext context = new SGPIDBContext();
        public IActionResult Login()
        {
            return View();
        }
        /*
         //CREATE
         Usuario usr =new Usuario();
         usr.PrimerNombre="Manuela";
         usr.SegundoNombre="Maria";
         usr.PrimerApellido="Munoz";
         usr.SegundoApellido="Vasco";
        usr.Email="manu@hotmail.com";
        usr.IdDocumento=1;
        usr.IdGenero=2;
        usr.IdPrograma=1;
        usr.NumeroDocumento="123456789";
        usr.Password="123456789";

        context.Add(usr);
        context.SaveChanges();
        */
        /*
        //QUERY
        Usuario usuario = new Usuario();
        usuario = Context.Usuarios.Single(b => b.NumeroDocumento=="123456789");
         */
        /*
        // Traer todos los usuarios
        List<Usuario>usuarios=new List<Usuario>();
        usuarios= Context.Usuarios.ToList();
         */
        /*
        //UPDATE
         var usr = context.Usuarios
        .Where(cursor => cursor.IdUsuario == 1)
        .FirstOrDefault();

        if (usr != null)
        {
        usr.SegundoNombre ="Maria";
        usr.SegundoApellido ="Vasco";

        context.Usuarios.Update(usr);
        context.SaveChanges();
        }

        */
        /*
        //DELETE
        var usuarioEliminar = context.Usuarios
        .Where(cursor => cursor.IdUsuario == 1)
        .FirstOrDefault();

        context.Usuarios.Remove(usuarioEliminar);
        return View();
        }
        */
        [HttpPost]

        //Anexo de olvidar contraseña
        public IActionResult Login(Usuario user)
        {
            string numerodoc = user.NumeroDocumento;
            string pass = user.Password;

            var usuarioLogin = context.Usuarios
                .Where(consulta => consulta.NumeroDocumento == numerodoc &&
                consulta.Password == pass).FirstOrDefault();
            if (usuarioLogin != null)
            {
                if (usuarioLogin.IdRol == 1)
                {
                    CrearUsuario();
                    return Redirect("Administrador/CrearUsuario");
                }
                //Coordinador
                else if (usuarioLogin.IdRol == 2)
                {
                    return Redirect("" + "Coordinador/BuscarCoordinador");
                }

                //Estudiante
                else if (usuarioLogin.IdRol == 3)

                {
                    return Redirect("Estudiante/ModificarEstudiante");

                }
                else { }
            }
            else
            {
                return ViewBag.mensaje = " Usuario no existe" +
                    "o usuario y/o contraseña invalida";
            }
            return View();
        }
        public IActionResult OlvidarContrasena()
        {
            return View();
        }
        //Anexo el de crear usuario
        public IActionResult CrearUsuario()
        {

            ViewBag.genero = context.Generos.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.tipodocumento= context.Documentos.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CrearUsuario(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();

            ViewBag.mensaje = "usuario creado exitosamente";
            ViewBag.genero = context.Generos.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.tipodocumento = context.Documentos.ToList();
            return View();
        }

        //Anexo el de buscar usuario
        public IActionResult BuscarUsuario()
        {
            Usuario us = new Usuario();
            return View(us);
        }
        [HttpPost]
        public IActionResult BuscarUsuario(Usuario usuario)
        {
            string numerodoc = usuario.NumeroDocumento;

            var user = context.Usuarios
                .Where(consulta => consulta.NumeroDocumento == numerodoc).FirstOrDefault();
            if (user != null)
            {
                return View(user);
            }
            else
                return View();
        }


        //Anexo de buscar usuario
        public IActionResult EliminarUsuario(Usuario user,int id)
        {
            Usuario usuario = user;
            if (usuario == null)
                return ViewBag.mensaje = "Eror al editar usuario";
            else
            {
                user.IdUsuario = id;
                context.Remove(user);
                context.SaveChanges();
            }

            return RedirectToAction("BuscarUsuario");
        }
            
        
        //Anexo de editar usuario
        public IActionResult EditarUsuario(int id)
        {
            ViewBag.tipodocumento = context.Documentos.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.genero = context.Generos.ToList();
            var listaUsuarios = context.Usuarios.Where(u => u.IdUsuario == id).ToList();
            if (listaUsuarios != null)
            {
                return View(listaUsuarios.SingleOrDefault());
            }
            else
            {
                return View();
            }
         
        }
        [HttpPost]
        public IActionResult EditarUsuario(Usuario user,int id)
        {
            Usuario usuario = user;
            if (usuario == null)
                return ViewBag.mensaje = "Error al editar usuario";
            else
            {
                user.IdUsuario = id;
                context.Update(user);
                context.SaveChanges();
                ViewBag.tipodocumento = context.Documentos.ToList();
                ViewBag.programa = context.Programas.ToList();
                ViewBag.rol = context.Rols.ToList();
                ViewBag.genero = context.Generos.ToList();
            }

            return RedirectToAction("BuscarUsuario");
        }


        //Anexo de Reportes
        public IActionResult ReportesUsuario()
        {
            return View();
        }
    }
}

