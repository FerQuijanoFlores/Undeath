using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.Web.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            List<Doctor> doctores = Doctor.GetAll();
            return View(doctores);
        }

        public ActionResult Registro(int id)
        {
            Doctor doctores = Doctor.GetById(id);
            return View(doctores);
        }
        public ActionResult Guardar(int id, string nombre, string apellido, string RFC, string cedulaProfecional, string email, string especialidad)
        {
            Doctor.Guardar(id, nombre, apellido, RFC, cedulaProfecional, email, especialidad);
            return RedirectToAction("Index"); 

        }

        public ActionResult Eliminar(int id)
        {
            Doctor.Eliminar(id);
            return RedirectToAction("Index");

        }
    }
}