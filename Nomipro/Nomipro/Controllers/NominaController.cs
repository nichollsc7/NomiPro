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
    public class NominaController : Controller
    {
        private NomiproEntities db = new NomiproEntities();

        // GET: Nomina
        public ActionResult Index()
        {
            var nominas = db.Nominas.Include(n => n.Cargo).Include(n => n.Control_Pago).Include(n => n.Empleado);
            return View(nominas.ToList());
        }

        // GET: Nomina/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.Nominas.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // GET: Nomina/Create
        public ActionResult Create()
        {
            ViewBag.ID_CargoN = new SelectList(db.Cargos, "ID_Cargo", "Nombre");
            ViewBag.ID_Control_PagoN = new SelectList(db.Control_Pago, "ID_Control_Pago", "Mes");
            ViewBag.ID_EmpleN = new SelectList(db.Empleados, "ID_Emple", "Nombre");
            return View();
        }

        // POST: Nomina/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Nomina,ID_EmpleN,ID_CargoN,ID_Control_PagoN,Mes,Estado,Subtotal,Total")] Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                db.Nominas.Add(nomina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CargoN = new SelectList(db.Cargos, "ID_Cargo", "Nombre", nomina.ID_CargoN);
            ViewBag.ID_Control_PagoN = new SelectList(db.Control_Pago, "ID_Control_Pago", "Mes", nomina.ID_Control_PagoN);
            ViewBag.ID_EmpleN = new SelectList(db.Empleados, "ID_Emple", "Nombre", nomina.ID_EmpleN);
            return View(nomina);
        }

        // GET: Nomina/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.Nominas.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CargoN = new SelectList(db.Cargos, "ID_Cargo", "Nombre", nomina.ID_CargoN);
            ViewBag.ID_Control_PagoN = new SelectList(db.Control_Pago, "ID_Control_Pago", "Mes", nomina.ID_Control_PagoN);
            ViewBag.ID_EmpleN = new SelectList(db.Empleados, "ID_Emple", "Nombre", nomina.ID_EmpleN);
            return View(nomina);
        }

        // POST: Nomina/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Nomina,ID_EmpleN,ID_CargoN,ID_Control_PagoN,Mes,Estado,Subtotal,Total")] Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nomina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CargoN = new SelectList(db.Cargos, "ID_Cargo", "Nombre", nomina.ID_CargoN);
            ViewBag.ID_Control_PagoN = new SelectList(db.Control_Pago, "ID_Control_Pago", "Mes", nomina.ID_Control_PagoN);
            ViewBag.ID_EmpleN = new SelectList(db.Empleados, "ID_Emple", "Nombre", nomina.ID_EmpleN);
            return View(nomina);
        }

        // GET: Nomina/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.Nominas.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // POST: Nomina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nomina nomina = db.Nominas.Find(id);
            db.Nominas.Remove(nomina);
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
