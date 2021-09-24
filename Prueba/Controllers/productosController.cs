using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prueba;
using Prueba.Filters;

namespace Prueba.Controllers
{
    public class productosController : Controller
    {
        private AVCEntities db = new AVCEntities();

        // GET: productos
        [AuthorizeUser(idOperacion: 7)]
        public ActionResult Index()
        {
            var productos = db.productos.Include(p => p.relacion_productos_por_pedido);
            return View(productos.ToList());
        }

        // GET: productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: productos/Create
        public ActionResult Create()
        {
            ViewBag.id_producto = new SelectList(db.relacion_productos_por_pedido, "id_relacion_productos_por_pedido", "id_relacion_productos_por_pedido");
            return View();
        }

        // POST: productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_producto,producto_nombre,producto_descripcion,producto_precio,producto_cantidad_existencia,producto_clave")] productos productos)
        {
            if (ModelState.IsValid)
            {
                db.productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_producto = new SelectList(db.relacion_productos_por_pedido, "id_relacion_productos_por_pedido", "id_relacion_productos_por_pedido", productos.id_producto);
            return View(productos);
        }

        // GET: productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_producto = new SelectList(db.relacion_productos_por_pedido, "id_relacion_productos_por_pedido", "id_relacion_productos_por_pedido", productos.id_producto);
            return View(productos);
        }

        // POST: productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_producto,producto_nombre,producto_descripcion,producto_precio,producto_cantidad_existencia,producto_clave")] productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_producto = new SelectList(db.relacion_productos_por_pedido, "id_relacion_productos_por_pedido", "id_relacion_productos_por_pedido", productos.id_producto);
            return View(productos);
        }

        // GET: productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productos productos = db.productos.Find(id);
            db.productos.Remove(productos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
