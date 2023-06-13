using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManzano.Models;
namespace TicketManzano.Controllers
{
    public class PrioridadController : Controller
    {
        private HelpdeskManzanoEntities db = new HelpdeskManzanoEntities();
        // GET: Prioridad
        public ActionResult Index()
        {
            var prioridadtickets = db.PrioridadTickets.ToList();
            return View(prioridadtickets);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PrioridadTickets prioridadtickets)
        {
            db.PrioridadTickets.Add(prioridadtickets);
            db.SaveChanges();
            return Json("");
        }

        public ActionResult Edit(int? id)
        {
            PrioridadTickets prioridadtickets = db.PrioridadTickets.Find(id);

            return PartialView("_Edit", prioridadtickets);
        }
        [HttpPost]
        public ActionResult Edit(PrioridadTickets prioridadtickets)
        {
            db.Entry(prioridadtickets).State = EntityState.Modified;
            db.SaveChanges();
            return Json("");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var prioridadtickets = db.PrioridadTickets.Find(id);
                return PartialView("_Delete", prioridadtickets);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var prioridadtickets = db.PrioridadTickets.Find(id);
            try
            {
                db.PrioridadTickets.Remove(prioridadtickets);
                db.SaveChanges();
                return Json("");
            }

            catch (Exception)
            {
                return Json("No se puede eliminar un tipo asignado a un Usuario.");
            }
        }


    }
}