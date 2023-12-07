using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaNutricional.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Panel()
        {
            ViewBag.Message = "Your panel page.";

            return View();
            
        }
        public ActionResult ValoresNutricionales()
        {
            ViewBag.Message = "Your panel page.";

            return View();
        }
        public ActionResult PLanDeAlimentacion()
        {
            ViewBag.Message = "Your panel page.";

            return View();
        }
        public ActionResult PlanificacionNutricional()
        {
            ViewBag.Message = "Your panel page.";

            return View();
        }
        public ActionResult DatosAntropometricos()
        {
            ViewBag.Message = "Your panel page.";

            return View();
        }
        public ActionResult Citas()
        {
            ViewBag.Message = "Your panel page.";

            return View();
        }
        public ActionResult CitasAgendadas()
        {
            ViewBag.Message = "Your panel page.";

            return View();
        }
        public ActionResult AgendarCitas()
        {
            ViewBag.Message = "Your panel page.";

            return View();
        }
        public ActionResult Recetas()
        {
            ViewBag.Message = "Your panel page.";

            return View();
        }
        public ActionResult VerRecetas()
        {
            ViewBag.Message = "Your panel page.";

            return View();
        }
        public ActionResult AgregarProducto()
        {
            ViewBag.Message = "Your panel page.";


            return View();
        }
        public ActionResult Tienda()
        {
            ViewBag.Message = "Your panel page.";


            return View();
        }
        public ActionResult ProductosReservados()
        {
            ViewBag.Message = "Your panel page.";


            return View();
        }
    }
}