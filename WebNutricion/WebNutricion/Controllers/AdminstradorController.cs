using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebNutricion.Controllers
{
    [Authorize(Roles = "Administrador")] // Se aplica a todas las acciones del controlador

    public class AdminstradorController : Controller
    {
        // GET: Adminstrador
        public ActionResult Index()
        {
            return View();
        }

        // GET: Adminstrador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Adminstrador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adminstrador/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Adminstrador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Adminstrador/Edit/5
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

        // GET: Adminstrador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Adminstrador/Delete/5
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
