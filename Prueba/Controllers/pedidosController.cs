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
    public class pedidosController : Controller
    {
        private AVCEntities db = new AVCEntities();

        // GET: pedidos
        [AuthorizeUser(idOperacion: 7)]
        public ActionResult Index()
        {
            var pedidos = db.pedidos.Include(p => p.relacion_productos_por_pedido).Include(p => p.usuarios);
            return View(pedidos.ToList());
        }

        // GET: pedidos/Details/5
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // GET: pedidos/Create
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Create()
        {
            ViewBag.id_pedido = new SelectList(db.relacion_productos_por_pedido, "id_relacion_productos_por_pedido", "id_relacion_productos_por_pedido");
            ViewBag.pedido_id_usuario = new SelectList(db.usuarios, "id_usuario", "usuario_nombre");
            return View();
        }

        // POST: pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Create([Bind(Include = "id_pedido,pedido_costo,pedido_descripcion,pedido_id_relacion_productos_por_pedido,pedido_id_usuario,pedido_nombre_cliente")] pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                db.pedidos.Add(pedidos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pedido = new SelectList(db.relacion_productos_por_pedido, "id_relacion_productos_por_pedido", "id_relacion_productos_por_pedido", pedidos.id_pedido);
            ViewBag.pedido_id_usuario = new SelectList(db.usuarios, "id_usuario", "usuario_nombre", pedidos.pedido_id_usuario);
            return View(pedidos);
        }

        // GET: pedidos/Edit/5
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pedido = new SelectList(db.relacion_productos_por_pedido, "id_relacion_productos_por_pedido", "id_relacion_productos_por_pedido", pedidos.id_pedido);
            ViewBag.pedido_id_usuario = new SelectList(db.usuarios, "id_usuario", "usuario_nombre", pedidos.pedido_id_usuario);
            return View(pedidos);
        }

        // POST: pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Edit([Bind(Include = "id_pedido,pedido_costo,pedido_descripcion,pedido_id_relacion_productos_por_pedido,pedido_id_usuario,pedido_nombre_cliente")] pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pedido = new SelectList(db.relacion_productos_por_pedido, "id_relacion_productos_por_pedido", "id_relacion_productos_por_pedido", pedidos.id_pedido);
            ViewBag.pedido_id_usuario = new SelectList(db.usuarios, "id_usuario", "usuario_nombre", pedidos.pedido_id_usuario);
            return View(pedidos);
        }

        // GET: pedidos/Delete/5
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // POST: pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult DeleteConfirmed(int id)
        {
            pedidos pedidos = db.pedidos.Find(id);
            db.pedidos.Remove(pedidos);
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
