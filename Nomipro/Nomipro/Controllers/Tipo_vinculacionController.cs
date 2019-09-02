using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nomipro.ModelDB;

namespace Nomipro.Controllers
{
    public class Tipo_vinculacionController : Controller
    {
        private NomiproEntities db = new NomiproEntities();

        // GET: Tipo_vinculacion
        public ActionResult Index()
        {
            return View(db.Tipo_vinculacion.ToList());
        }

        // GET: Tipo_vinculacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_vinculacion tipo_vinculacion = db.Tipo_vinculacion.Find(id);
            if (tipo_vinculacion == null)
            {
                return HttpNotFound();
            }
            return View(tipo_vinculacion);
        }

        // GET: Tipo_vinculacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_vinculacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_vinculacion,Descripcion,Estado")] Tipo_vinculacion tipo_vinculacion)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_vinculacion.Add(tipo_vinculacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_vinculacion);
        }

        // GET: Tipo_vinculacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_vinculacion tipo_vinculacion = db.Tipo_vinculacion.Find(id);
            if (tipo_vinculacion == null)
            {
                return HttpNotFound();
            }
            return View(tipo_vinculacion);
        }

        // POST: Tipo_vinculacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_vinculacion,Descripcion,Estado")] Tipo_vinculacion tipo_vinculacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_vinculacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_vinculacion);
        }

        // GET: Tipo_vinculacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_vinculacion tipo_vinculacion = db.Tipo_vinculacion.Find(id);
            if (tipo_vinculacion == null)
            {
                return HttpNotFound();
            }
            return View(tipo_vinculacion);
        }

        // POST: Tipo_vinculacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_vinculacion tipo_vinculacion = db.Tipo_vinculacion.Find(id);
            db.Tipo_vinculacion.Remove(tipo_vinculacion);
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
