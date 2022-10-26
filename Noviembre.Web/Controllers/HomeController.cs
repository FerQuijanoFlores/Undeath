using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.Web.Controllers
{
    public class HomeController : Controller
    {

        //acciones de controlador
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Bienvenido() { 
        
            return Bienvenido();

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
    }
}