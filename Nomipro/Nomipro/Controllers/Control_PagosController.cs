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
    public class Control_PagosController : Controller
    {
        private NomiproEntities db = new NomiproEntities();

        // GET: Control_Pagos
        public ActionResult Index()
        {
            var control_Pago = db.Control_Pago.Include(c => c.Empleado);
            return View(control_Pago.ToList());
        }

        // GET: Control_Pagos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Control_Pago control_Pago = db.Control_Pago.Find(id);
            if (control_Pago == null)
            {
                return HttpNotFound();
            }
            return View(control_Pago);
        }

        // GET: Control_Pagos/Create
        public ActionResult Create()
        {
            ViewBag.ID_EmpleCP = new SelectList(db.Empleados, "ID_Emple", "Nombre");
            return View();
        }

        // POST: Control_Pagos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Control_Pago,ID_EmpleCP,Valor_Horas_Extras,Valor_Parafiscal,Mes")] Control_Pago control_Pago)
        {
            if (ModelState.IsValid)
            {
                db.Control_Pago.Add(control_Pago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_EmpleCP = new SelectList(db.Empleados, "ID_Emple", "Nombre", control_Pago.ID_EmpleCP);
            return View(control_Pago);
        }

        // GET: Control_Pagos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Control_Pago control_Pago = db.Control_Pago.Find(id);
            if (control_Pago == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_EmpleCP = new SelectList(db.Empleados, "ID_Emple", "Nombre", control_Pago.ID_EmpleCP);
            return View(control_Pago);
        }

        // POST: Control_Pagos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Control_Pago,ID_EmpleCP,Valor_Horas_Extras,Valor_Parafiscal,Mes")] Control_Pago control_Pago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(control_Pago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_EmpleCP = new SelectList(db.Empleados, "ID_Emple", "Nombre", control_Pago.ID_EmpleCP);
            return View(control_Pago);
        }

        // GET: Control_Pagos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Control_Pago control_Pago = db.Control_Pago.Find(id);
            if (control_Pago == null)
            {
                return HttpNotFound();
            }
            return View(control_Pago);
        }

        // POST: Control_Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Control_Pago control_Pago = db.Control_Pago.Find(id);
            db.Control_Pago.Remove(control_Pago);
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
