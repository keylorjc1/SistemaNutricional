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
    public class planAlimentacionController : Controller
    {
        private Nutricion db = new Nutricion();

        // GET: planAlimentacion
        public ActionResult Index()
        {
            return View(db.planAlimentacions.ToList());
        }

        // GET: planAlimentacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planAlimentacion planAlimentacion = db.planAlimentacions.Find(id);
            if (planAlimentacion == null)
            {
                return HttpNotFound();
            }
            return View(planAlimentacion);
        }

        // GET: planAlimentacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: planAlimentacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPlan,comida,alimentos,calorias")] planAlimentacion planAlimentacion)
        {
            if (ModelState.IsValid)
            {
                db.planAlimentacions.Add(planAlimentacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planAlimentacion);
        }

        // GET: planAlimentacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planAlimentacion planAlimentacion = db.planAlimentacions.Find(id);
            if (planAlimentacion == null)
            {
                return HttpNotFound();
            }
            return View(planAlimentacion);
        }

        // POST: planAlimentacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPlan,comida,alimentos,calorias")] planAlimentacion planAlimentacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planAlimentacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planAlimentacion);
        }

        // GET: planAlimentacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planAlimentacion planAlimentacion = db.planAlimentacions.Find(id);
            if (planAlimentacion == null)
            {
                return HttpNotFound();
            }
            return View(planAlimentacion);
        }

        // POST: planAlimentacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            planAlimentacion planAlimentacion = db.planAlimentacions.Find(id);
            db.planAlimentacions.Remove(planAlimentacion);
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
