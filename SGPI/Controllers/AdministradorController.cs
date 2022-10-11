using Microsoft.AspNetCore.Mvc;

namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        //Anexo de olvidar contraseña
        public IActionResult OlvidarContrasena()
        {
            return View();
        }
        //Anexo el de crear usuario
        public IActionResult CrearUsuario()
        {
            return View();
        }
        //Anexo el de buscar usuario
        public IActionResult BuscarUsuario()
        {
            return View();
        }
        //Anexo de buscar usuario
        public IActionResult EliminarUsuario()
        {
            return View();
        }
        //Anexo de editar usuario
        public IActionResult EditarUsuario()
        {
            return View();
        }
        //Anexo de Reportes
        public IActionResult ReportesUsuario()
        {
            return View();
        }
    }
}
