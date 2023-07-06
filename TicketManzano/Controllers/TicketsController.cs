using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManzano.Models;
using System.Net.Mail;
using System.Net;

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
        public ActionResult Create(Tickets tickets)
        {
            try
            {
                string destinatario = Session["email"] as string; 
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



    }
}