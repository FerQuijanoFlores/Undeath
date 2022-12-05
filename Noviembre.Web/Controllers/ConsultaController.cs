using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.Web.Controllers
{
    public class ConsultaController : Controller
    {
        // GET: Consulta
        public ActionResult Index()
        {
            List<Consulta> consultas = Consulta.GetAll();
            return View(consultas);
        }

        public ActionResult Eliminar(int id)
        {
            Consulta.Eliminar(id);
            return RedirectToAction("Index");

        }
    }
}