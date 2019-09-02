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
    public class Horas_ExtrasController : Controller
    {
        private NomiproEntities db = new NomiproEntities();

        // GET: Horas_Extras
        public ActionResult Index()
        {
            return View(db.Horas_Extras.ToList());
        }

        // GET: Horas_Extras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horas_Extras horas_Extras = db.Horas_Extras.Find(id);
            if (horas_Extras == null)
            {
                return HttpNotFound();
            }
            return View(horas_Extras);
        }

        // GET: Horas_Extras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Horas_Extras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Hextras,Nombre,Valor,Estado")] Horas_Extras horas_Extras)
        {
            if (ModelState.IsValid)
            {
                db.Horas_Extras.Add(horas_Extras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(horas_Extras);
        }

        // GET: Horas_Extras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horas_Extras horas_Extras = db.Horas_Extras.Find(id);
            if (horas_Extras == null)
            {
                return HttpNotFound();
            }
            return View(horas_Extras);
        }

        // POST: Horas_Extras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Hextras,Nombre,Valor,Estado")] Horas_Extras horas_Extras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horas_Extras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(horas_Extras);
        }

        // GET: Horas_Extras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horas_Extras horas_Extras = db.Horas_Extras.Find(id);
            if (horas_Extras == null)
            {
                return HttpNotFound();
            }
            return View(horas_Extras);
        }

        // POST: Horas_Extras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Horas_Extras horas_Extras = db.Horas_Extras.Find(id);
            db.Horas_Extras.Remove(horas_Extras);
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
