using Noviembre.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Noviembre.Web.Controllers
{
    public class DocumentoNacionalidadController : Controller
    {
        // GET: DocumentoNacionalidad
        public ActionResult Index()
        {
            List<DocumentoNacionalidad> documentos = DocumentoNacionalidad.GetAll();
            return View(documentos);
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Guardar(string nombre)
        { //nombre del input
            DocumentoNacionalidad.Guardar(nombre);
            return RedirectToAction("Index");

        }
    }
}