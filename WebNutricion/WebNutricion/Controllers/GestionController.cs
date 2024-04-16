using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNutricion.Models;

namespace WebNutricion.Controllers
{
    public class GestionController : Controller
    {
        private Nutricion db = new Nutricion();

        // GET: Gestion/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Gestion/Create
        public ActionResult Create(string userId)
        {
            ViewBag.UserId = userId; // Pasar userId a la vista
            ViewBag.UserIdSelectList = new SelectList(db.AspNetUsers, "Id", "Email"); // ViewBag para el DropDownList

            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(planAlimentacion planAlimentacion, planificacionNutricional planificacionNutricional, string userId)
        {
            if (ModelState.IsValid)
            {
                planAlimentacion.idUser = userId;
                planificacionNutricional.idUser = userId;


                // Guardar los datos de planAlimentacion y planificacionNutricional
                db.planAlimentacions.Add(planAlimentacion);
                db.planificacionNutricionals.Add(planificacionNutricional);
                db.SaveChanges();

                // Redirigir al método Create de Gestion con el mismo userId
                return RedirectToAction("Index", "Home", new { userId = planificacionNutricional.idUser });
            }

            ViewBag.UserId = planAlimentacion.idUser; // Pasar la cédula nuevamente en caso de que haya errores de validación

            ViewBag.UserId = planificacionNutricional.idUser; // Pasar la cédula nuevamente en caso de que haya errores de validación
            return View();
        }

        // GET: Gestion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Gestion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Gestion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Gestion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
