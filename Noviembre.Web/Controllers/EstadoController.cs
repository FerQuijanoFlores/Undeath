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
        // GET: Estado
        public ActionResult Index()
        {
            List<Estado> estados = Estado.GetAll();
            return View();
        }
    }
}