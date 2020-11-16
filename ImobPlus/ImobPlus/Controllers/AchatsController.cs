using ImobPlus.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using ImobPlus.Models;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImobPlus.Controllers
{
    public class AchatsController : Controller
    {
        private ImobDbContext _ctx;

        public AchatsController()
        {
            _ctx = new ImobDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }

        // GET: Achats
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Location()
        {
            var res = _ctx.Posts.ToList();
            return View(res);
        }

        public ActionResult LocationDetails(int id)
        {
            var post = _ctx.Posts.SingleOrDefault(c => c.Id_Post == id);

            if (post == null)
                return HttpNotFound();

            return View(post);
        }

        [HttpPost]
        public async Task<ActionResult> LocationDetails(ContactPro contactPro, int id)
        {
            var post = _ctx.Posts.SingleOrDefault(c => c.Id_Post == id);
           
            var context = new ImobDbContext();


            if (ModelState.IsValid)
            {
                var constru = new ContactPro();
                constru.Nom = contactPro.Nom;
                constru.Bailleur = post.Email_Bailleur;
                constru.EmailCont = contactPro.EmailCont;
                constru.Message = contactPro.Message;


                context.ContactPros.Add(constru);
                ViewBag.Message = "Demande d'aide prise en compte";
                context.SaveChanges();

                return View("LocationDetails", post);

                /*var message = new MailMessage();
                message.To.Add(new MailAddress(post.Email_Bailleur));
                message.From = new MailAddress(constru.EmailCont);
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

                    return View("LocationDetails", post);
                }*/
            }

            return View(post);
        }
    }
}