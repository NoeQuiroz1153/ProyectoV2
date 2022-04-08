using ProyectoV2.DBContext;
using ProyectoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoV2.Controllers
{
    public class UnidadController : Controller
    {

        private LaBodegaContext context;
        public UnidadController()
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
            
            var unidad = context.Unidad.ToList();
            return View(unidad);
        }
        public ActionResult Nuevo()
        {
            var unidad = new Unidad();
            return View("Nuevo", unidad);
        }
        public ActionResult Editar(int id)
        {
            var unidadInDb = context.Unidad.SingleOrDefault(c => c.UnidadMedidaId == id);
            if (unidadInDb == null)
                return HttpNotFound();

            return View("Nuevo", unidadInDb);
        }
        public ActionResult Detalles(int id)
        {
            var unidadInDb = context.Unidad.SingleOrDefault(c => c.UnidadMedidaId == id);
            if (unidadInDb == null)
                return HttpNotFound();

            return View(unidadInDb);
        }
        public ActionResult Eliminar(int id)
        {
            var unidadInDb = context.Unidad.SingleOrDefault(c => c.UnidadMedidaId == id);
            if (unidadInDb == null)
                return HttpNotFound();

            return View(unidadInDb);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminar(int id)
        {
            var unidadInDb = context.Unidad.SingleOrDefault(c => c.UnidadMedidaId == id);
            if (unidadInDb == null)
                return HttpNotFound();

            context.Unidad.Remove(unidadInDb);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Guardar(Unidad unidad)
        {
            if (!ModelState.IsValid)
                return View("Nuevo", unidad);

            if (unidad.UnidadMedidaId == 0)
            {
                context.Unidad.Add(unidad);
            }
            else
            {
                var unidadInDb = context.Unidad.SingleOrDefault(c => c.UnidadMedidaId == unidad.UnidadMedidaId);
                unidadInDb.Codigo = unidad.Codigo;
                unidadInDb.Descripcion = unidad.Descripcion;
                unidadInDb.Estado = unidad.Estado;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}