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
    public class valoresNutricionaleController : Controller
    {
        private Nutricion db = new Nutricion();

        // GET: valoresNutricionale
        public ActionResult Index()
        {
            return View(db.valoresNutricionales.ToList());
        }

        // GET: valoresNutricionale/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            valoresNutricionale valoresNutricionale = db.valoresNutricionales.Find(id);
            if (valoresNutricionale == null)
            {
                return HttpNotFound();
            }
            return View(valoresNutricionale);
        }

        // GET: valoresNutricionale/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: valoresNutricionale/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idValores,informacionConsulta,historial")] valoresNutricionale valoresNutricionale)
        {
            if (ModelState.IsValid)
            {
                db.valoresNutricionales.Add(valoresNutricionale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valoresNutricionale);
        }

        // GET: valoresNutricionale/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            valoresNutricionale valoresNutricionale = db.valoresNutricionales.Find(id);
            if (valoresNutricionale == null)
            {
                return HttpNotFound();
            }
            return View(valoresNutricionale);
        }

        // POST: valoresNutricionale/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idValores,informacionConsulta,historial")] valoresNutricionale valoresNutricionale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valoresNutricionale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valoresNutricionale);
        }

        // GET: valoresNutricionale/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            valoresNutricionale valoresNutricionale = db.valoresNutricionales.Find(id);
            if (valoresNutricionale == null)
            {
                return HttpNotFound();
            }
            return View(valoresNutricionale);
        }

        // POST: valoresNutricionale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            valoresNutricionale valoresNutricionale = db.valoresNutricionales.Find(id);
            db.valoresNutricionales.Remove(valoresNutricionale);
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
