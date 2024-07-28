using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebNutricion.Models;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;

namespace WebNutricion.Controllers
{
    [Authorize(Roles = "Administrador,Usuario")] // Se aplica a todas las acciones del controlador

    public class UserController : Controller
    {
        private NutricionModel db = new NutricionModel();

        // GET: AspNetUser
        public ActionResult Index()
        {
            // Obtener el nombre de usuario del usuario actualmente autenticado
            string userName = User.Identity.Name;

            // Buscar al usuario en la base de datos basado en su nombre de usuario
            var currentUser = db.AspNetUsers.FirstOrDefault(u => u.UserName == userName);

            // Verificar si se encontró al usuario
            if (currentUser != null)
            {
                // Devolver la vista con los datos del usuario actual
                return View(currentUser);
            }
            else
            {
                // Manejar el caso en el que no se encuentra al usuario
                // Esto podría ser una redirección a una página de error, por ejemplo
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult ShowDiet(string id)
        {
            // Verifica si el ID no es nulo
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Busca el usuario asociado al ID en la tabla AspNetUsers
            AspNetUser usuario = db.AspNetUsers.FirstOrDefault(u => u.Id == id);

            // Verifica si se encontró el usuario
            if (usuario == null)
            {
                return HttpNotFound("No se encontró ningún usuario asociado a este Id.");
            }

            // Busca los datos nutricionales asociados al ID del usuario
            var planAlimentacionData = db.planAlimentacions.Where(d => d.idUser == id).OrderByDescending(d => d.fecha).FirstOrDefault();

            // Crea un modelo de vista que contenga los datos más recientes
            var viewModel = new Tuple< planAlimentacion>(planAlimentacionData);

            // Pasa los datos a la vista
            return View(viewModel);
        }
      
      

        public ActionResult ShowProgress(string id)
        {
            // Verifica si el ID no es nulo
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Busca el usuario asociado al ID en la tabla AspNetUsers
            AspNetUser usuario = db.AspNetUsers.FirstOrDefault(u => u.Id == id);

            // Verifica si se encontró el usuario
            if (usuario == null)
            {
                return HttpNotFound("No se encontró ningún usuario asociado a este Id.");
            }

            // Busca los datos antropométricos asociados al ID del usuario
            var planificacionNutricionalData = db.planificacionNutricionals.Where(d => d.idUser == id).OrderByDescending(d => d.fecha).ToList();

            // Crea un modelo de vista que contenga las listas de datos antropométricos
            var viewModel = new Tuple<List<planificacionNutricional>>(planificacionNutricionalData);

            // Pasa los datos antropométricos a la vista
            return View(viewModel);
        }

        // GET: ShowAntropometricData/CreateNew
        public ActionResult CreateNew(string motivo, string expectativas, string informacionConsulta, string historial, string Cedula, DateTime fecha, string idUser)
        {
            ViewBag.Motivo = motivo;
            ViewBag.Expectativas = expectativas;
            ViewBag.InformacionConsulta = informacionConsulta;
            ViewBag.Historial = historial;
            ViewBag.Cedula = Cedula;
            ViewBag.Fecha = fecha;
            ViewBag.IdUser = idUser;

            return View();
        }


        // POST: ShowAntropometricData/CreateNew
        // Este método maneja el envío del formulario para crear un nuevo registro de valoresNutricionale
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNew([Bind(Include = "motivo,expectativas,informacionConsulta,historial,fecha,idUser")] valoresNutricionale valoresNutricionale, string idUser)
        {
            if (ModelState.IsValid)
            {
                // Asignamos el ID de usuario al objeto valoresNutricionale
                valoresNutricionale.idUser = idUser;

                db.valoresNutricionales.Add(valoresNutricionale);
                db.SaveChanges();

                // Redirigimos a la acción Create del controlador Gestion para crear el plan de alimentación
                return RedirectToAction("ShowAntropometricData", new { id = idUser });
            }

            // Si hay un error en el modelo, volvemos a cargar la vista con los errores
            return View(valoresNutricionale);
        }
        // GET: ShowAntropometricData/CreateNew
        // GET: ShowAntropometricData/CreateNew2
        public ActionResult CreateNew2(int peso, int altura, int IMC, int grasacorporal, int metabolismobasal, int caloriasdiarias, int proteinas, int carbohidratos, int grasas, string objetivo, DateTime fecha, string idUser)
        {
            ViewBag.Peso = peso;
            ViewBag.Altura = altura;
            ViewBag.IMC = IMC;
            ViewBag.Grasacorporal = grasacorporal;
            ViewBag.Metabolismobasal = metabolismobasal;
            ViewBag.Caloriasdiarias = caloriasdiarias;
            ViewBag.Proteinas = proteinas;
            ViewBag.Carbohidratos = carbohidratos;
            ViewBag.Grasas = grasas;
            ViewBag.Objetivo = objetivo;
            ViewBag.Fecha = fecha;
            ViewBag.IdUser = idUser;

            return View();

        }

        // POST: ShowAntropometricData/CreateNew2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNew2([Bind(Include = "peso,altura,IMC,grasacorporal,metabolismobasal,caloriasdiarias,proteinas,carbohidratos,grasas,objetivo,Cedula,fecha,idUser")] planificacionNutricional planificacionNutricional, string idUser)
        {
            if (ModelState.IsValid)
            {
                // Asignar el ID de usuario a los objetos
                planificacionNutricional.idUser = idUser;

                // Agregar los objetos a la base de datos y guardar los cambios
                db.planificacionNutricionals.Add(planificacionNutricional);
                db.SaveChanges();

                // Redireccionar a la acción Index del controlador Home
                return RedirectToAction("ShowAntropometricData", new { id = idUser });
            }

            // Si hay errores en el modelo, volver a cargar la vista con los errores
            return View(planificacionNutricional);
        }

        // GET: ShowAntropometricData/CreateNew2
        public ActionResult CreateNew3(string desayuno, string almuerzo, string merienda, string cena, string calorias, DateTime fecha, string idUser)
        {
            ViewBag.Desayuno = desayuno;
            ViewBag.Almuerzo = almuerzo;
            ViewBag.Merienda = merienda;
            ViewBag.Cena = cena;
            ViewBag.Calorias = calorias;
            ViewBag.Fecha = fecha;
            ViewBag.IdUser = idUser;

            return View();

        }

        // POST: ShowAntropometricData/CreateNew2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNew3([Bind(Include = "idPlan,desayuno,almuerzo,merienda,cena,calorias,Cedula,fecha,idUser")] planAlimentacion planAlimentacion, string idUser)
        {
            if (ModelState.IsValid)
            {
                // Asignar el ID de usuario a los objetos
                planAlimentacion.idUser = idUser;

                // Agregar los objetos a la base de datos y guardar los cambios
                db.planAlimentacions.Add(planAlimentacion);
                db.SaveChanges();

                // Redireccionar a la acción Index del controlador Home
                return RedirectToAction("ShowAntropometricData", new { id = idUser });
            }

            // Si hay errores en el modelo, volver a cargar la vista con los errores
            return View(planAlimentacion);
        }



        // GET: AspNetUser/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // GET: AspNetUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AspNetUser/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Nombre,Apellidos,Telefono,Cedula")] AspNetUser aspNetUser)
        {
            if (ModelState.IsValid)
            {
                db.AspNetUsers.Add(aspNetUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aspNetUser);
        }

        // GET: AspNetUser/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // POST: AspNetUser/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Nombre,Apellidos,Telefono,Cedula")] AspNetUser aspNetUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aspNetUser);
        }

        // GET: AspNetUser/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // POST: AspNetUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(aspNetUser);
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
