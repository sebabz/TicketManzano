using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManzano.Models;
using System.Net.Mail;
using System.Net;
using System.IO;

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
            ViewBag.usuario = new SelectList(db.Usuarios, "IDUsuario", "CorreoElectronico");
            ViewBag.asunto = new SelectList(db.AsuntoTickets, "IDAsunto", "NombreAsunto");
            ViewBag.Prioridad = new SelectList(db.PrioridadTickets, "IDPrioridad", "NombrePrioridad");
            ViewBag.estado = new SelectList(db.EstadoTickets, "IDEstado", "NombreEstado");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tickets tickets, HttpPostedFileBase formFile)
        {
            try
            {

                string destinatario = Session["email"] as string;

                if (formFile != null && formFile.ContentLength > 0)
                {
                    // Guarda la imagen en el servidor
                    string fileName = Path.GetFileName(formFile.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    formFile.SaveAs(filePath);

                    // Guarda la ruta de la imagen en el modelo de ticket
                    tickets.RutaImagen = filePath;
                }


                db.Tickets.Add(tickets);
                db.SaveChanges();

                // Enviar correo electrónico al usuario
                EnviarCorreoElectronico(tickets.IDTicket);


                return Json("");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Json("Ha ocurrido un error, intentelo mas tarde.");
            }
        }

        private void EnviarCorreoElectronico(int ticketId)
        {
            try
            {
                Tickets ticket = db.Tickets.Find(ticketId);
                string destinatario = Session["email"] as string;

                MailMessage message = new MailMessage();
                message.From = new MailAddress("ticketsmanzano@outlook.com");
                message.To.Add(destinatario);
                message.Subject = "Nuevo ticket creado";
                message.Body = "Se ha creado un nuevo ticket con el ID: " + ticket.IDTicket;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp-mail.outlook.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential("ticketsmanzano@outlook.com", "manzano1925");
                

                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo electrónico: " + ex.Message);
            }
        }



        public ActionResult Edit(int? id)
        {

            Tickets tickets = db.Tickets.Find(id);

            
            ViewBag.correousuario = new SelectList(db.Usuarios, "IDUsuario", "CorreoElectronico", tickets.IDUsuario);
            ViewBag.prioridad = new SelectList(db.PrioridadTickets, "IDPrioridad", "NombrePrioridad", tickets.IDTicket);
            ViewBag.asunto = new SelectList(db.AsuntoTickets, "IDAsunto", "NombreAsunto", tickets.IDTicket);
            ViewBag.estado = new SelectList(db.EstadoTickets, "IDEstado", "NombreEstado", tickets.IDEstado);


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
                return Json("No se puede eliminar el ticket.");
            }
        }

        public ActionResult DownloadImage(int id)
        {
            var ticket = db.Tickets.Find(id);
            if (ticket != null)
            {
                // Obtén la ruta de la imagen desde la base de datos
                string imagePath = ticket.RutaImagen;

                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    // Obtén el nombre de archivo de la ruta de la imagen
                    string fileName = Path.GetFileName(imagePath);

                    // Devuelve la imagen como un archivo descargable
                    return File(imagePath, "image/jpeg", fileName);
                }
            }

            // Si no se encuentra la imagen, puedes redirigir o mostrar un mensaje de error
            return RedirectToAction("Index"); // o mostrar un mensaje de error
        }



    }
}