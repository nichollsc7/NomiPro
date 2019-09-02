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
    public class HExtraxEmpleadosController : Controller
    {
        private NomiproEntities db = new NomiproEntities();

        // GET: HExtraxEmpleados
        public ActionResult Index()
        {
            var hExtraxEmpleadoes = db.HExtraxEmpleadoes.Include(h => h.Empleado).Include(h => h.Horas_Extras);
            return View(hExtraxEmpleadoes.ToList());
        }

        // GET: HExtraxEmpleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HExtraxEmpleado hExtraxEmpleado = db.HExtraxEmpleadoes.Find(id);
            if (hExtraxEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(hExtraxEmpleado);
        }

        // GET: HExtraxEmpleados/Create
        public ActionResult Create()
        {
            ViewBag.ID_Emple = new SelectList(db.Empleados, "ID_Emple", "Nombre");
            ViewBag.ID_HExtras = new SelectList(db.Horas_Extras, "ID_Hextras", "Nombre");
            return View();
        }

        // POST: HExtraxEmpleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HEXE,ID_Emple,ID_HExtras,Numero_Horas,Mes")] HExtraxEmpleado hExtraxEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.HExtraxEmpleadoes.Add(hExtraxEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Emple = new SelectList(db.Empleados, "ID_Emple", "Nombre", hExtraxEmpleado.ID_Emple);
            ViewBag.ID_HExtras = new SelectList(db.Horas_Extras, "ID_Hextras", "Nombre", hExtraxEmpleado.ID_HExtras);
            return View(hExtraxEmpleado);
        }

        // GET: HExtraxEmpleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HExtraxEmpleado hExtraxEmpleado = db.HExtraxEmpleadoes.Find(id);
            if (hExtraxEmpleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Emple = new SelectList(db.Empleados, "ID_Emple", "Nombre", hExtraxEmpleado.ID_Emple);
            ViewBag.ID_HExtras = new SelectList(db.Horas_Extras, "ID_Hextras", "Nombre", hExtraxEmpleado.ID_HExtras);
            return View(hExtraxEmpleado);
        }

        // POST: HExtraxEmpleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HEXE,ID_Emple,ID_HExtras,Numero_Horas,Mes")] HExtraxEmpleado hExtraxEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hExtraxEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Emple = new SelectList(db.Empleados, "ID_Emple", "Nombre", hExtraxEmpleado.ID_Emple);
            ViewBag.ID_HExtras = new SelectList(db.Horas_Extras, "ID_Hextras", "Nombre", hExtraxEmpleado.ID_HExtras);
            return View(hExtraxEmpleado);
        }

        // GET: HExtraxEmpleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HExtraxEmpleado hExtraxEmpleado = db.HExtraxEmpleadoes.Find(id);
            if (hExtraxEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(hExtraxEmpleado);
        }

        // POST: HExtraxEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HExtraxEmpleado hExtraxEmpleado = db.HExtraxEmpleadoes.Find(id);
            db.HExtraxEmpleadoes.Remove(hExtraxEmpleado);
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
