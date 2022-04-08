using ProyectoV2.DBContext;
using ProyectoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoV2.Controllers
{
    public class ClasiProductoController : Controller
    {
        private LaBodegaContext context;
        public ClasiProductoController()
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
            // muestra las clasificaciones

            var clasiproducto = context.ClasiProductos.ToList();
            return View(clasiproducto);
        }
        public ActionResult Nuevo()
        {
            var clasiproducto = new ClasiProductos();
            return View("Nuevo", clasiproducto);
        }
        public ActionResult Editar(int id)
        {
            var clasificacionesInDb = context.ClasiProductos.SingleOrDefault(c => c.ClasiProducId == id);
            if (clasificacionesInDb == null)
                return HttpNotFound();

            return View("Nuevo", clasificacionesInDb);
        }
        public ActionResult Detalles(int id)
        {
            var clasificacionesInDb = context.ClasiProductos.SingleOrDefault(c => c.ClasiProducId == id);
            if (clasificacionesInDb == null)
                return HttpNotFound();

            return View(clasificacionesInDb);
        }
        public ActionResult Eliminar(int id)
        {
            var clasificacionesInDb = context.ClasiProductos.SingleOrDefault(c => c.ClasiProducId == id);
            if (clasificacionesInDb == null)
                return HttpNotFound();

            return View(clasificacionesInDb);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminar(int id)
        {
            var clasificacionesInDb = context.ClasiProductos.SingleOrDefault(c => c.ClasiProducId == id);
            if (clasificacionesInDb == null)
                return HttpNotFound();

            context.ClasiProductos.Remove(clasificacionesInDb);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Guardar(ClasiProductos clasiproductos)
        {
            if (!ModelState.IsValid)
                return View("Nuevo", clasiproductos);

            if (clasiproductos.ClasiProducId == 0)
            {
                context.ClasiProductos.Add(clasiproductos);
            }
            else
            {
                var clasificacionesInDb = context.ClasiProductos.SingleOrDefault(c => c.ClasiProducId == clasiproductos.ClasiProducId);
                clasificacionesInDb.Codigo = clasiproductos.Codigo;
                clasificacionesInDb.Descripcion = clasiproductos.Descripcion;
                clasificacionesInDb.Estado = clasiproductos.Estado;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}