using ProyectoV2.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using ProyectoV2.Models;

namespace ProyectoV2.Controllers
{
    public class ClienteController : Controller
    {
        private LaBodegaContext context;
        public ClienteController()
        {
            context = new LaBodegaContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            context.Dispose();
        }

        public ActionResult Index()
        {

            var cliente = context.Clientes.Include(c => c.Clasificacion).ToList();
            return View(cliente);
        }



    }
}