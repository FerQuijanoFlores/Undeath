using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.Web.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        public ActionResult Index()
        {
            List<Paciente> pacientes = Paciente.GetAll();
            return View(pacientes);

        }

        public ActionResult Registro(int id)
        {
            Paciente pacientes = Paciente.GetById(id);
            return View(pacientes);
        }

        public ActionResult Guardar(int id, string nombre, string apellido, string nss, string curp, string email)
        {
            Paciente.Guardar(id, nombre, apellido, nss, curp, email);
            return RedirectToAction("Index");


        }

        public ActionResult Eliminar(int id)
        {
            Paciente.Eliminar(id);
            return RedirectToAction("Index");

        }
    }
}