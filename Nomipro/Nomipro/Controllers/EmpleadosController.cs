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
    public class EmpleadosController : Controller
    {
        private NomiproEntities db = new NomiproEntities();

        // GET: Empleados
        public ActionResult Index()
        {
            var empleados = db.Empleados.Include(e => e.Cargo).Include(e => e.Horario).Include(e => e.Tipo_vinculacion);
            return View(empleados.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.ID_Cargo = new SelectList(db.Cargos, "ID_Cargo", "Nombre");
            ViewBag.ID_Horario = new SelectList(db.Horarios, "ID_Horario", "Tipo_Horario");
            ViewBag.ID_Vinculacion = new SelectList(db.Tipo_vinculacion, "ID_vinculacion", "Descripcion");
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Emple,Nombre,Apellido,Correo,Telefono,Tipo_Documento,Numero_Documento,ID_Cargo,ID_Vinculacion,ID_Horario,Estado")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cargo = new SelectList(db.Cargos, "ID_Cargo", "Nombre", empleado.ID_Cargo);
            ViewBag.ID_Horario = new SelectList(db.Horarios, "ID_Horario", "Tipo_Horario", empleado.ID_Horario);
            ViewBag.ID_Vinculacion = new SelectList(db.Tipo_vinculacion, "ID_vinculacion", "Descripcion", empleado.ID_Vinculacion);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cargo = new SelectList(db.Cargos, "ID_Cargo", "Nombre", empleado.ID_Cargo);
            ViewBag.ID_Horario = new SelectList(db.Horarios, "ID_Horario", "Tipo_Horario", empleado.ID_Horario);
            ViewBag.ID_Vinculacion = new SelectList(db.Tipo_vinculacion, "ID_vinculacion", "Descripcion", empleado.ID_Vinculacion);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Emple,Nombre,Apellido,Correo,Telefono,Tipo_Documento,Numero_Documento,ID_Cargo,ID_Vinculacion,ID_Horario,Estado")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cargo = new SelectList(db.Cargos, "ID_Cargo", "Nombre", empleado.ID_Cargo);
            ViewBag.ID_Horario = new SelectList(db.Horarios, "ID_Horario", "Tipo_Horario", empleado.ID_Horario);
            ViewBag.ID_Vinculacion = new SelectList(db.Tipo_vinculacion, "ID_vinculacion", "Descripcion", empleado.ID_Vinculacion);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleados.Find(id);
            db.Empleados.Remove(empleado);
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
