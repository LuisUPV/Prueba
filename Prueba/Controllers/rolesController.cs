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
    public class rolesController : Controller
    {
        private AVCEntities db = new AVCEntities();

        // GET: roles
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Index()
        {
            var roles = db.roles.Include(r => r.usuarios);
            return View(roles.ToList());
        }

        // GET: roles/Details/5
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            roles roles = db.roles.Find(id);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
        }

        // GET: roles/Create
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Create()
        {
            ViewBag.id_rol = new SelectList(db.usuarios, "id_usuario", "usuario_nombre");
            return View();
        }

        // POST: roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Create([Bind(Include = "id_rol,rol_nombre")] roles roles)
        {
            if (ModelState.IsValid)
            {
                db.roles.Add(roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_rol = new SelectList(db.usuarios, "id_usuario", "usuario_nombre", roles.id_rol);
            return View(roles);
        }

        // GET: roles/Edit/5
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            roles roles = db.roles.Find(id);
            if (roles == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_rol = new SelectList(db.usuarios, "id_usuario", "usuario_nombre", roles.id_rol);
            return View(roles);
        }

        // POST: roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Edit([Bind(Include = "id_rol,rol_nombre")] roles roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_rol = new SelectList(db.usuarios, "id_usuario", "usuario_nombre", roles.id_rol);
            return View(roles);
        }

        // GET: roles/Delete/5
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            roles roles = db.roles.Find(id);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
        }

        // POST: roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult DeleteConfirmed(int id)
        {
            roles roles = db.roles.Find(id);
            db.roles.Remove(roles);
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
