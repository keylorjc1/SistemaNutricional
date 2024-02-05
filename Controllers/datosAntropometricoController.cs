using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaNutricional.Models;

namespace SistemaNutricional.Controllers
{
    public class datosAntropometricoController : Controller
    {
        private Nutricion db = new Nutricion();

        // GET: datosAntropometrico
        public ActionResult Index()
        {
            var datosAntropometricos = db.datosAntropometricos.Include(d => d.planificacionNutricional);
            return View(datosAntropometricos.ToList());
        }

        // GET: datosAntropometrico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            datosAntropometrico datosAntropometrico = db.datosAntropometricos.Find(id);
            if (datosAntropometrico == null)
            {
                return HttpNotFound();
            }
            return View(datosAntropometrico);
        }

        // GET: datosAntropometrico/Create
        public ActionResult Create()
        {
            ViewBag.idDatos = new SelectList(db.planificacionNutricionals, "idPlanificacionNutricional", "objetivo");
            return View();
        }

        // POST: datosAntropometrico/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDatos,peso,altura,IMC,grasacorporal,datosAnaliticos,progreso")] datosAntropometrico datosAntropometrico)
        {
            if (ModelState.IsValid)
            {
                db.datosAntropometricos.Add(datosAntropometrico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDatos = new SelectList(db.planificacionNutricionals, "idPlanificacionNutricional", "objetivo", datosAntropometrico.idDatos);
            return View(datosAntropometrico);
        }

        // GET: datosAntropometrico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            datosAntropometrico datosAntropometrico = db.datosAntropometricos.Find(id);
            if (datosAntropometrico == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDatos = new SelectList(db.planificacionNutricionals, "idPlanificacionNutricional", "objetivo", datosAntropometrico.idDatos);
            return View(datosAntropometrico);
        }

        // POST: datosAntropometrico/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDatos,peso,altura,IMC,grasacorporal,datosAnaliticos,progreso")] datosAntropometrico datosAntropometrico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datosAntropometrico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDatos = new SelectList(db.planificacionNutricionals, "idPlanificacionNutricional", "objetivo", datosAntropometrico.idDatos);
            return View(datosAntropometrico);
        }

        // GET: datosAntropometrico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            datosAntropometrico datosAntropometrico = db.datosAntropometricos.Find(id);
            if (datosAntropometrico == null)
            {
                return HttpNotFound();
            }
            return View(datosAntropometrico);
        }

        // POST: datosAntropometrico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            datosAntropometrico datosAntropometrico = db.datosAntropometricos.Find(id);
            db.datosAntropometricos.Remove(datosAntropometrico);
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
