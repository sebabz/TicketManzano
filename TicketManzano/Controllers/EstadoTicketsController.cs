using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManzano.Models;

namespace TicketManzano.Controllers
{
    
    public class EstadoTicketsController : Controller
    {
        private HelpdeskManzanoEntities db = new HelpdeskManzanoEntities();
        // GET: AsuntoTickets
        public ActionResult Index()
        {
            var estadotickets = db.EstadoTickets.ToList();
            return View(estadotickets);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EstadoTickets estadotickets)
        {
            db.EstadoTickets.Add(estadotickets);
            db.SaveChanges();
            return Json("");
        }

        public ActionResult Edit(int? id)
        {
            EstadoTickets estadotickets = db.EstadoTickets.Find(id);

            return PartialView("_Edit", estadotickets);
        }
        [HttpPost]
        public ActionResult Edit(EstadoTickets estadotickets)
        {
            db.Entry(estadotickets).State = EntityState.Modified;
            db.SaveChanges();
            return Json("");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var estadotickets = db.EstadoTickets.Find(id);
                return PartialView("_Delete", estadotickets);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var estadotickets = db.EstadoTickets.Find(id);
            try
            {
                db.EstadoTickets.Remove(estadotickets);
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