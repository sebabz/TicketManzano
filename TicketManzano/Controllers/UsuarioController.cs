using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManzano.Models;

namespace TicketManzano.Controllers
{
    public class UsuarioController : Controller

    {
        private HelpdeskManzanoEntities db = new HelpdeskManzanoEntities();
        // GET: Usuario
        public ActionResult Index()
        {

            var usuario = db.Usuarios.ToList();
            return View(usuario);


        }

        public ActionResult Create()
        {
            ViewBag.tipo = new SelectList(db.TipoUsuario, "id_tipousuario", "nombretipo");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuarios usuarios)
        {
            try
            {
                db.Usuarios.Add(usuarios);
                db.SaveChanges();
                return Json("");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Json("Ha ocurrido un error, intentelo mas tarde.");
            }
        }
    }
}