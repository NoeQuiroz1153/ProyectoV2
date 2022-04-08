using ProyectoV2.DBContext;
using ProyectoV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProyectoV2.Controllers
{
    public class ClasificacionController : Controller
    {

        private LaBodegaContext context;

        public ClasificacionController()
        {
            context = new LaBodegaContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            context.Dispose();
        }
        // GET: CategoriaProducto
        public ActionResult Index()
        {
            var clasificacion = context.Clasificacion.ToList();
            return View(clasificacion);
        }

        public ActionResult Crear()
        {
            var clasificacion = new Clasificacion();
            return View(clasificacion);
        }

        [HttpPost]
        public ActionResult Crear(Clasificacion clasificacion)
        {
            if (!ModelState.IsValid)
            {
                var clasifi = clasificacion;
                return View(clasifi);
            }
            context.Clasificacion.Add(clasificacion);
            context.SaveChanges();
            return RedirectToAction("Index", "Clasificacion");
        }

        public ActionResult Editar(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clasificacion = context.Clasificacion.SingleOrDefault(cc => cc.ClasificacionId == id);
            if (clasificacion == null)
                return HttpNotFound();

            return View(clasificacion);
        }

        [HttpPost]
        public ActionResult Editar(Clasificacion clasificacion)
        {
            if (!ModelState.IsValid)
            {
                var clasific = clasificacion;
                return View(clasific);
            }
            if (clasificacion.ClasificacionId == 0)
                return HttpNotFound();

            var clasificacionDb = context.Clasificacion.SingleOrDefault(cc => cc.ClasificacionId == clasificacion.ClasificacionId);
            if (clasificacion == null)
                return HttpNotFound();
            clasificacionDb.Codigo = clasificacion.Codigo;
            clasificacionDb.Descripcion = clasificacion.Descripcion;
            clasificacionDb.Estado = clasificacion.Estado;

            context.SaveChanges();
            return RedirectToAction("Index", "Clasificacion");
        }

        public ActionResult Detalle(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clasificacion = context.Clasificacion.SingleOrDefault(cc => cc.ClasificacionId == id);
            if (clasificacion == null)
                return HttpNotFound();

            return View(clasificacion);
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clasificacion = context.Clasificacion.SingleOrDefault(cc => cc.ClasificacionId == id);

            if (clasificacion == null)
                return HttpNotFound();

            return View(clasificacion);
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {

            if (id == 0)
                return HttpNotFound();

            var clasificacionDb = context.Clasificacion.SingleOrDefault(cc => cc.ClasificacionId == id);
            if (clasificacionDb == null)
                return HttpNotFound();

            context.Clasificacion.Remove(clasificacionDb);
            context.SaveChanges();
            return RedirectToAction("Index", "Clasificacion");
        }





    }
}