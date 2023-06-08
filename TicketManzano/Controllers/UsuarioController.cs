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


        public ActionResult Edit(int? id)
        {

            Usuarios usuario = db.Usuarios.Find(id);

            ViewBag.tipo = new SelectList(db.TipoUsuario, "id_tipousuario", "nombretipo", usuario.id_tipousuario);
            
            return PartialView("_Edit", usuario);
        }
        [HttpPost]
        public ActionResult Edit(Usuarios usuario)
        {

            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();
            return Json("");
        }


        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var usuario = db.Usuarios.Find(id);
                return PartialView("_Delete", usuario);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var usuarios = db.Usuarios.Find(id);
            try
            {
                db.Usuarios.Remove(usuarios);
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



//        public ActionResult Delete(int? id)
//        {
//            var usuario = db.Usuarios.Find(id);
//            return PartialView("_Delete", usuario);
//        }
//        [HttpPost]
//        public ActionResult Eliminar(int id)
//        {
//            var usuario = db.Usuarios.Find(id);

//            try
//            {

//                if (usuario != null)
//                {
//                    db.Usuarios.Remove(usuario);
//                    db.SaveChanges();
//                    return Json("");
//                }
//            }
//            catch (Exception)
//            {
//                return Json("No se ha podido eliminar el Usuario");
//            }
//            return Json("No se puede eliminar un usuario que este asignado");
//        }


//    }
//}