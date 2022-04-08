using ProyectoV2.DBContext;
using ProyectoV2.Models;
using ProyectoV2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoV2.Controllers
{
    public class ProductoController : Controller
    {
        private LaBodegaContext context;

        public ProductoController()
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
            //muestra los productos
            var productos = context.Productos.ToList();
            return View(productos);
        }
        public ActionResult Nuevo()
        {
            var productos = new Productos();
            var clasiproductos = context.ClasiProductos.Where(c => c.Estado == true).ToList();
            var unidad = context.Unidad.Where(c => c.Estado == true).ToList();
            var viewModel = new ProductoView()
            {
                Productos = productos,
                ClasiProductos = clasiproductos,
                Unidad = unidad
            };
            return View("ProductoForm", viewModel);
        }

        public ActionResult Editar(int id)
        {
            var productos = context.Productos.SingleOrDefault(c => c.ProductoId == id);
            if (productos == null)
                return HttpNotFound();

            var clasiproductos = context.ClasiProductos.Where(c => c.Estado == true).ToList();
            var unidad = context.Unidad.Where(c => c.Estado == true).ToList();
            var viewModel = new ProductoView()
            {
                Productos = productos,
                ClasiProductos = clasiproductos,
                Unidad = unidad
            };
            return View("ProductoForm", viewModel);
        }

        [HttpPost]
        public ActionResult Guardar(Productos productos)
        {
            if (productos.ProductoId == 0)
            {
                productos.FechaCreacion = DateTime.Now;

            }
            if (productos.ClasiProducId == 0)
            {
                ModelState.AddModelError("", "Debe seleccionar una clasificacion de Producto");
            }

            if (!ModelState.IsValid)
            {
                var clasiproductos = context.ClasiProductos.Where(c => c.Estado == true).ToList();
                var unidad = context.Unidad.Where(c => c.Estado == true).ToList();
                var viewModel = new ProductoView()
                {
                    Productos = productos,
                    ClasiProductos = clasiproductos,
                    Unidad = unidad
                };
                return View("ProductoForm", viewModel);
            }

            if (productos.ProductoId == 0)
            {
                context.Productos.Add(productos);
            }
            else
            {
                var productosInDb = context.Productos.SingleOrDefault(c => c.ProductoId == productos.ProductoId);
                productosInDb.Codigo = productos.Codigo;
                productosInDb.Descripcion = productos.Descripcion;
                productosInDb.FechaCreacion = productos.FechaCreacion;
                productosInDb.Precio = productos.Precio;
                productosInDb.Estado = productos.Estado;
                productosInDb.ClasiProducId = productos.ClasiProducId;
                productosInDb.UnidadMedidaId = productos.UnidadMedidaId;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detalles(int id)
        {
            var productoS = context.Productos.SingleOrDefault(c => c.ProductoId == id);
            if (productoS == null)
                return HttpNotFound();

            return View(productoS);
        }

        public ActionResult Eliminar(int id)
        {
            var productos = context.Productos.SingleOrDefault(c => c.ProductoId == id);
            if (productos == null)
                return HttpNotFound();

            return View(productos);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminar(int id)
        {
            var productos = context.Productos.SingleOrDefault(c => c.ProductoId == id);
            if (productos == null)
                return HttpNotFound();

            context.Productos.Remove(productos);
            context.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}