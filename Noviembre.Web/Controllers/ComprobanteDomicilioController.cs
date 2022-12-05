using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.Web.Controllers
{
    public class ComprobanteDomicilioController : Controller
    {
        // GET: ComprobanteDomicilio
        public ActionResult Index()
        {
            List<ComprobanteDomicilio> comprobantes = ComprobanteDomicilio.GetAll();
            return View(comprobantes);
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Guardar(string nombre)
        {
            ComprobanteDomicilio.Guardar(nombre);
            return RedirectToAction("Index");


        }
    }
}