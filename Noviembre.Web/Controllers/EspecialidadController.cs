using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.Web.Controllers
{
    public class EspecialidadController : Controller
    {
        // GET: Especialidad
        public ActionResult Index()
        {
            List<Especialidad> especialidad = Especialidad.GetAll();
            return View(especialidad);
        }

        public ActionResult Registro(int id)
        {
            Especialidad especialidad = Especialidad.GetById(id);
            return View(especialidad);
        }
        public ActionResult Guardar(int id, string nombre)
        {
            Especialidad.Guardar(id, nombre);
            return RedirectToAction("Index"); //Invocar la lista de Paciente


            //List<Paciente> estados = Paciente.GetAll(); //PUEDE SER TAMBIEN ASI PERO SE REPETIRIA LO DE ARRIBA
            //return View("Index", estados);

        }
    }
}