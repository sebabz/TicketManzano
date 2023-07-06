using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManzano.Models;

namespace TicketManzano.Controllers
{
    
    public class AsuntoTicketsController : Controller
    {
        private HelpdeskManzanoEntities db = new HelpdeskManzanoEntities();
        // GET: AsuntoTickets
        public ActionResult Index()
        {
            var asuntotickets = db.AsuntoTickets.ToList();
            return View(asuntotickets);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AsuntoTickets asuntotickets)
        {
            db.AsuntoTickets.Add(asuntotickets);
            db.SaveChanges();
            return Json("");
        }

        public ActionResult Edit(int? id)
        {
            AsuntoTickets asuntotickets = db.AsuntoTickets.Find(id);

            return PartialView("_Edit", asuntotickets);
        }
        [HttpPost]
        public ActionResult Edit(AsuntoTickets asuntotickets)
        {
            db.Entry(asuntotickets).State = EntityState.Modified;
            db.SaveChanges();
            return Json("");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var asuntotickets = db.AsuntoTickets.Find(id);
                return PartialView("_Delete", asuntotickets);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var asuntotickets = db.AsuntoTickets.Find(id);
            try
            {
                db.AsuntoTickets.Remove(asuntotickets);
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