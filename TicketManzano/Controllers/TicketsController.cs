using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManzano.Models;

namespace TicketManzano.Controllers
{
    public class TicketsController : Controller
    {
        private HelpdeskManzanoEntities db = new HelpdeskManzanoEntities();
        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = db.Tickets.ToList();
            return View(tickets);
        }
    


        public ActionResult Create()
        {
            ViewBag.tipo = new SelectList(db.TipoUsuario, "id_tipousuario", "nombretipo");
            ViewBag.usuario = new SelectList(db.Usuarios, "IDUsuario", "CorreoElectronico");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tickets tickets)
        {
            try
            {
                db.Tickets.Add(tickets);
                db.SaveChanges();
                return Json("");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Json("Ha ocurrido un error, intentelo mas tarde.");
            }
        }


        public ActionResult Edit(int? id)
        {

            Tickets tickets = db.Tickets.Find(id);

            ViewBag.Usuario = new SelectList(db.Usuarios, "id_tipousuario", "nombretipo", tickets.IDUsuario);

            return PartialView("_Edit", tickets);
        }
        [HttpPost]
        public ActionResult Edit(Tickets tickets)
        {

            db.Entry(tickets).State = EntityState.Modified;
            db.SaveChanges();
            return Json("");
        }


        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var tickets = db.Tickets.Find(id);
                return PartialView("_Delete", tickets);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var tickets = db.Tickets.Find(id);
            try
            {
                db.Tickets.Remove(tickets);
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