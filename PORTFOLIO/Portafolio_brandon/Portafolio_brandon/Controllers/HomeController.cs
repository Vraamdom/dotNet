using Microsoft.AspNetCore.Mvc;
using Portafolio_brandon.Models;
using System.Diagnostics;

namespace Portafolio_brandon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var proyectos = ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel()
            {
                
            };
            return View(modelo);
        }

        private List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>()
            {
                new Proyecto
                {
                    Titulo = "App para certificaciones Microsoft",
                    Descripcion = "Portal de Entretenimiento Tecnologías Microsoft",
                    Link= "https://lean.microsoft.com",
                    ImagenURL = "~/imagenes/microso.jpg"
                },
                new Proyecto
                {
                    Titulo = "Grupo bancolombia",
                    Descripcion = "Desarrollo app clientes",
                    Link= "https://www.bancolombia.com",
                    ImagenURL = "~/imagenes/bancolombia.jpg"
                },
                new Proyecto
                {
                    Titulo = "App virtual",
                    Descripcion = "Desarrollo app virtual para compras",
                    Link= "https://www.exito.com",
                    ImagenURL = "~/imagenes/virtual.jpg"
                },
                new Proyecto
                {
                    Titulo = "Simulador prestamos",
                    Descripcion = "Desarrollo app prestamos",
                    Link= "https://www.bancoldex.com",
                    ImagenURL = "~/imagenes/prestamo.jpg"
                },
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
