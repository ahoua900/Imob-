using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using ImobPlus.DAL;
using System.Threading.Tasks;
using ImobPlus.Models;
using System.Web;
using System.Web.Mvc;

namespace ImobPlus.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(Contacts contacts)
        {

            var context = new ImobDbContext();


            if (ModelState.IsValid)
            {
                var constru = new Contacts();
                constru.NomPrenom = contacts.NomPrenom;
                constru.Email = contacts.Email;
                constru.Precoccupation = contacts.Precoccupation;


                context.Contacts.Add(contacts);
                ViewBag.Message = "Demande d'aide prise en compte";
                context.SaveChanges();

                var message = new MailMessage();
                message.To.Add(new MailAddress(constru.Email));
                message.From = new MailAddress(constru.Email);
                message.Subject = "IMOB+ Votre agence vous suit partout dans le monde";
                message.Body = string.Format("IMOB+ est heureux de vous compter parmir les clients de l'agence. Veillez rester en attente; une reponse sera vite donnée");
                message.IsBodyHtml = true;

                //configuration smtp

                using (var smtp = new SmtpClient())
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    var credential = new NetworkCredential
                    {
                        UserName = "IMOB+",
                        Password = "ta0610ami"
                    };
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    await smtp.SendMailAsync(message);

                    return View("Contact", contacts);
                }
            }
            return View();
        }
        public ActionResult DeleteContact(int id)
        {
            if (id != 0)
            {
                var db = new ImobDbContext();
                var dr = db.Contacts.SingleOrDefault(s => s.Id_Contact == id);
                db.Contacts.Remove(dr);
                db.SaveChanges();
                ViewBag.supe = "Préoccupation supprimée ave succés";
            }
            return View();
        }
    }
}