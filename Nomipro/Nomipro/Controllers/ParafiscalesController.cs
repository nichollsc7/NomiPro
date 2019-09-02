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
    public class ParafiscalesController : Controller
    {
        private NomiproEntities db = new NomiproEntities();

        // GET: Parafiscales
        public ActionResult Index()
        {
            return View(db.Parafiscales.ToList());
        }

        // GET: Parafiscales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parafiscale parafiscale = db.Parafiscales.Find(id);
            if (parafiscale == null)
            {
                return HttpNotFound();
            }
            return View(parafiscale);
        }

        // GET: Parafiscales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parafiscales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Parafiscales,Nombre,Valor,Estado")] Parafiscale parafiscale)
        {
            if (ModelState.IsValid)
            {
                db.Parafiscales.Add(parafiscale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parafiscale);
        }

        // GET: Parafiscales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parafiscale parafiscale = db.Parafiscales.Find(id);
            if (parafiscale == null)
            {
                return HttpNotFound();
            }
            return View(parafiscale);
        }

        // POST: Parafiscales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Parafiscales,Nombre,Valor,Estado")] Parafiscale parafiscale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parafiscale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parafiscale);
        }

        // GET: Parafiscales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parafiscale parafiscale = db.Parafiscales.Find(id);
            if (parafiscale == null)
            {
                return HttpNotFound();
            }
            return View(parafiscale);
        }

        // POST: Parafiscales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parafiscale parafiscale = db.Parafiscales.Find(id);
            db.Parafiscales.Remove(parafiscale);
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
