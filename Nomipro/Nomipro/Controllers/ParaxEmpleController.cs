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
    public class ParaxEmpleController : Controller
    {
        private NomiproEntities db = new NomiproEntities();

        // GET: ParaxEmple
        public ActionResult Index()
        {
            var paraxEmples = db.ParaxEmples.Include(p => p.Empleado).Include(p => p.Parafiscale);
            return View(paraxEmples.ToList());
        }

        // GET: ParaxEmple/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParaxEmple paraxEmple = db.ParaxEmples.Find(id);
            if (paraxEmple == null)
            {
                return HttpNotFound();
            }
            return View(paraxEmple);
        }

        // GET: ParaxEmple/Create
        public ActionResult Create()
        {
            ViewBag.ID_EmpleP = new SelectList(db.Empleados, "ID_Emple", "Nombre");
            ViewBag.ID_Parafiscales = new SelectList(db.Parafiscales, "ID_Parafiscales", "Nombre");
            return View();
        }

        // POST: ParaxEmple/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PAEM,ID_Parafiscales,ID_EmpleP,Mes")] ParaxEmple paraxEmple)
        {
            if (ModelState.IsValid)
            {
                db.ParaxEmples.Add(paraxEmple);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_EmpleP = new SelectList(db.Empleados, "ID_Emple", "Nombre", paraxEmple.ID_EmpleP);
            ViewBag.ID_Parafiscales = new SelectList(db.Parafiscales, "ID_Parafiscales", "Nombre", paraxEmple.ID_Parafiscales);
            return View(paraxEmple);
        }

        // GET: ParaxEmple/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParaxEmple paraxEmple = db.ParaxEmples.Find(id);
            if (paraxEmple == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_EmpleP = new SelectList(db.Empleados, "ID_Emple", "Nombre", paraxEmple.ID_EmpleP);
            ViewBag.ID_Parafiscales = new SelectList(db.Parafiscales, "ID_Parafiscales", "Nombre", paraxEmple.ID_Parafiscales);
            return View(paraxEmple);
        }

        // POST: ParaxEmple/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PAEM,ID_Parafiscales,ID_EmpleP,Mes")] ParaxEmple paraxEmple)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paraxEmple).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_EmpleP = new SelectList(db.Empleados, "ID_Emple", "Nombre", paraxEmple.ID_EmpleP);
            ViewBag.ID_Parafiscales = new SelectList(db.Parafiscales, "ID_Parafiscales", "Nombre", paraxEmple.ID_Parafiscales);
            return View(paraxEmple);
        }

        // GET: ParaxEmple/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParaxEmple paraxEmple = db.ParaxEmples.Find(id);
            if (paraxEmple == null)
            {
                return HttpNotFound();
            }
            return View(paraxEmple);
        }

        // POST: ParaxEmple/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParaxEmple paraxEmple = db.ParaxEmples.Find(id);
            db.ParaxEmples.Remove(paraxEmple);
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
