using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.Web.Controllers
{
    public class ConsultorioController : Controller
    {
        // GET: Consultorio
        public ActionResult Index()
        {
            List<Consultorio> consultorios = Consultorio.GetAll();
            return View(consultorios);
        }
        public ActionResult Registro(int id)
        {
            Consultorio consultorio = Consultorio.GetById(id);
            return View(consultorio);
        }
        public ActionResult Guardar(int id, int numeroExterior, int idDoctor)
        {
            Consultorio.Guardar(id, numeroExterior, idDoctor);
            return RedirectToAction("Index");

        }

        public ActionResult Eliminar(int id)
        {
            Consultorio.Eliminar(id);
            return RedirectToAction("Index");

        }
    }
}