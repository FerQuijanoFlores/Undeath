using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.Web.Controllers
{
    public class EstadoController : Controller
    {
        // GET: Paciente
        public ActionResult Index()
        {
            List<Estado> estados = Estado.GetAll();
            return View(estados);

        }

        public ActionResult Registro(int id)
        {
            Estado estado = Estado.GetById(id);
            return View(estado);
        }

        public ActionResult Guardar(int id, string nombre)
        {
            Estado.Guardar(id, nombre);
            return RedirectToAction("Index"); //Invocar la lista de Paciente


            //List<Paciente> estados = Paciente.GetAll(); //PUEDE SER TAMBIEN ASI PERO SE REPETIRIA LO DE ARRIBA
            //return View("Index", estados);

        }
    }
}