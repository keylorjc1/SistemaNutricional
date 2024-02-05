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
    public class planificacionNutricionalController : Controller
    {
        private Nutricion db = new Nutricion();

        // GET: planificacionNutricional
        public ActionResult Index()
        {
            var planificacionNutricionals = db.planificacionNutricionals.Include(p => p.datosAntropometrico);
            return View(planificacionNutricionals.ToList());
        }

        // GET: planificacionNutricional/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planificacionNutricional planificacionNutricional = db.planificacionNutricionals.Find(id);
            if (planificacionNutricional == null)
            {
                return HttpNotFound();
            }
            return View(planificacionNutricional);
        }

        // GET: planificacionNutricional/Create
        public ActionResult Create()
        {
            ViewBag.idPlanificacionNutricional = new SelectList(db.datosAntropometricos, "idDatos", "datosAnaliticos");
            return View();
        }

        // POST: planificacionNutricional/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPlanificacionNutricional,porcentajedemasagrasa,metabolismobasal,actividadfisica,caloriasdiarias,proteinas,carbohidratos,grasas,objetivo,peso,altura")] planificacionNutricional planificacionNutricional)
        {
            if (ModelState.IsValid)
            {
                db.planificacionNutricionals.Add(planificacionNutricional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPlanificacionNutricional = new SelectList(db.datosAntropometricos, "idDatos", "datosAnaliticos", planificacionNutricional.idPlanificacionNutricional);
            return View(planificacionNutricional);
        }

        // GET: planificacionNutricional/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planificacionNutricional planificacionNutricional = db.planificacionNutricionals.Find(id);
            if (planificacionNutricional == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPlanificacionNutricional = new SelectList(db.datosAntropometricos, "idDatos", "datosAnaliticos", planificacionNutricional.idPlanificacionNutricional);
            return View(planificacionNutricional);
        }

        // POST: planificacionNutricional/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPlanificacionNutricional,porcentajedemasagrasa,metabolismobasal,actividadfisica,caloriasdiarias,proteinas,carbohidratos,grasas,objetivo,peso,altura")] planificacionNutricional planificacionNutricional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planificacionNutricional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPlanificacionNutricional = new SelectList(db.datosAntropometricos, "idDatos", "datosAnaliticos", planificacionNutricional.idPlanificacionNutricional);
            return View(planificacionNutricional);
        }

        // GET: planificacionNutricional/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planificacionNutricional planificacionNutricional = db.planificacionNutricionals.Find(id);
            if (planificacionNutricional == null)
            {
                return HttpNotFound();
            }
            return View(planificacionNutricional);
        }

        // POST: planificacionNutricional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            planificacionNutricional planificacionNutricional = db.planificacionNutricionals.Find(id);
            db.planificacionNutricionals.Remove(planificacionNutricional);
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
