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
    public class usuariosController : Controller
    {
        private AVCEntities db = new AVCEntities();

        // GET: usuarios
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Index()
        {
            var usuarios = db.usuarios.Include(u => u.roles);
            return View(usuarios.ToList());
        }

        // GET: usuarios/Details/5
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // GET: usuarios/Create
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Create()
        {
            ViewBag.id_usuario = new SelectList(db.roles, "id_rol", "rol_nombre");
            return View();
        }

        // POST: usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Create([Bind(Include = "id_usuario,usuario_nombre,usuario_password,usuario_correo,usuario_id_rol,usuario_apellido_paterno,usuario_apellido_materno,usuario_foto")] usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_usuario = new SelectList(db.roles, "id_rol", "rol_nombre", usuarios.id_usuario);
            return View(usuarios);
        }

        // GET: usuarios/Edit/5
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_usuario = new SelectList(db.roles, "id_rol", "rol_nombre", usuarios.id_usuario);
            return View(usuarios);
        }

        // POST: usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Edit([Bind(Include = "id_usuario,usuario_nombre,usuario_password,usuario_correo,usuario_id_rol,usuario_apellido_paterno,usuario_apellido_materno,usuario_foto")] usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_usuario = new SelectList(db.roles, "id_rol", "rol_nombre", usuarios.id_usuario);
            return View(usuarios);
        }

        // GET: usuarios/Delete/5
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult DeleteConfirmed(int id)
        {
            usuarios usuarios = db.usuarios.Find(id);
            db.usuarios.Remove(usuarios);
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
