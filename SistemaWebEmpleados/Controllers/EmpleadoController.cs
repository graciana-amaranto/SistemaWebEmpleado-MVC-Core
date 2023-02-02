using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleados.Data;
using SistemaWebEmpleados.Models;
using System.Linq;

namespace SistemaWebEmpleados.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly DBEmpleadosContext context;

        public EmpleadoController(DBEmpleadosContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var empleados = context.Empleados.ToList();
            return View(empleados);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var empleado = new Empleado();
            return View("Create", empleado);
        }

        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                context.Empleados.Add(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var empleado = TraerUno(id);
            if (empleado == null)
                return NotFound();
            else
                return View("Details", empleado);
        }

        [HttpGet]
        public IActionResult FiltrarPorTitulo(string title)
        {
            var empleados = context.Empleados.Where(i => i.Titulo == title).ToList();

            if (empleados == null)
                return NotFound();

            return View("FiltrarPorTitulo", empleados);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var empleado = TraerUno(id);

            if (empleado == null)
                return NotFound();

            return View("Delete", empleado);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var empleado = TraerUno(id);
            if (empleado == null)
                return NotFound();
            else
            {
                context.Empleados.Remove(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var empleado = TraerUno(id);
            return View("Edit", empleado);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Empleado empleado)
        {
            if (!ModelState.IsValid) return BadRequest();

            context.Entry(empleado).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        private Empleado TraerUno(int id)
        {
            return context.Empleados.Find(id);
        }
    }
}

