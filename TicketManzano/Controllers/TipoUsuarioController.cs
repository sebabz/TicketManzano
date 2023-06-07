using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManzano.Models;

namespace TicketManzano.Controllers
{

    public class TipousuarioController : Controller
    {
        private HelpdeskManzanoEntities db = new HelpdeskManzanoEntities();
        // GET: Tipousuario
        public ActionResult Index()
        {

            var tipousuario = db.TipoUsuario.ToList();
            return View(tipousuario);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TipoUsuario tipousuario)
        {
            db.TipoUsuario.Add(tipousuario);
            db.SaveChanges();
            return Json("");
        }

        public ActionResult Edit(int? id)
        {
            TipoUsuario tipousuario = db.TipoUsuario.Find(id);
            return PartialView("_Edit", tipousuario);
        }
        [HttpPost]
        public ActionResult Edit(TipoUsuario tipousuario)
        {
            db.Entry(tipousuario).State = EntityState.Modified;
            db.SaveChanges();
            return Json("");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var tipousuario = db.TipoUsuario.Find(id);
                return PartialView("_Delete", tipousuario);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var tipousuario = db.TipoUsuario.Find(id);
            try
            {
                db.TipoUsuario.Remove(tipousuario);
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