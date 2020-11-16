using ImobPlus.DAL;
using ImobPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ImobPlus.Controllers
{
    public class ConstruireController : Controller
    {

        // GET: Construire
        public ActionResult Index()
        {
            var context = new ImobDbContext();
            return View();
        }
        //construire get
        public ActionResult Contruire()
        {
            var context = new ImobDbContext();
            ModelState.Clear();
            return View();
        }
        //construire post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contruire(Construire Const)
        {
            var context = new ImobDbContext();


            if (ModelState.IsValid)
            {
                var constru = new Construire();
                constru.NameConst = Const.NameConst;
                constru.EmailConst = Const.EmailConst;
                constru.MessageConst = Const.MessageConst;
                constru.LieuConst = Const.LieuConst;
                context.Construires.Add(Const);
                ViewBag.Message = "Demande d'aide prise en compte";
                context.SaveChanges();
                return View("Construire", Const);
                /*var message = new MailMessage();
                message.To.Add(new MailAddress(Const.EmailConst));
                message.From = new MailAddress(Const.EmailConst);
                message.Subject = "IMOB+ Votre agence vous suit partout dans le monde";
                message.Body = string.Format("IMOB+ est heureux de vous compter parmir les clients de l'agence. Veillez confirmer votre demande en cliquant sur le bouton suivant");
                message.IsBodyHtml = true;

                //configuration smtp

                using (var smtp = new SmtpClient())
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    var credential = new NetworkCredential
                    {
                        UserName = "at193542@gmail.com",
                        Password = "ta0610ami"
                    };
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    await smtp.SendMailAsync(message);

                    return View("Construire", Const);
                }*/
            }

            return View("Contruire");
        }

        ///

        //Demenager get
        public ActionResult Demenager()
        {
            var context = new ImobDbContext();
            ModelState.Clear();
            return View();
        }
        //Demenager post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Demenager(Demenagement Dem)
        {
            var context = new ImobDbContext();

            if (ModelState.IsValid)
            {
                var demenage = new Demenagement();
                demenage.NameDem = Dem.NameDem;
                demenage.EmailDem = Dem.EmailDem;
                demenage.DestinaDem = Dem.DestinaDem;
                demenage.LieuDepartDem = Dem.LieuDepartDem;
                demenage.MessagDem = Dem.MessagDem;

                context.Demenagements.Add(Dem);
                ViewBag.Message = "Demande d'aide prise en compte";
                context.SaveChanges();
                return View("Demenager", Dem);

                /*var message = new MailMessage();
                message.To.Add(new MailAddress(Dem.EmailDem));
                message.Subject = "IMOB+ Votre agence vous suit partout dans le monde";
                message.Body = string.Format("IMOB+ est heureux de vous compter parmir les clients de l'agence. Veillez confirmer votre demande en cliquant sur le bouton suivant");
                message.IsBodyHtml = true;

                //configuration smtp

                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    *//*smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    var credential = new NetworkCredential
                    {
                        UserName = "at193542@gmail.com",
                        Password = "ta0610ami"
                    };
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    await smtp.SendMailAsync(message);*//*

                    return View("Demenager", Dem);
                }*/


            }

            return View("Demenager");
        }





        //Investir get
        public ActionResult Investir()
        {
            var context = new ImobDbContext();
            ModelState.Clear();
            return View();
        }

        //Investir post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Investir(Investir Inves)
        {
            var context = new ImobDbContext();

            if (ModelState.IsValid)
            {
                var invest = new Investir();
                invest.NameInvest = Inves.NameInvest;
                invest.EmailInvest = Inves.EmailInvest;
                invest.MessageInvest = Inves.MessageInvest;


                context.Investirs.Add(Inves);
                ViewBag.Message = "Demande d'aide prise en compte";
                context.SaveChanges();

                /*var message = new MailMessage();
                message.To.Add(new MailAddress(Inves.EmailInvest));
                message.From = new MailAddress(Inves.EmailInvest);
                message.Subject = "IMOB+ Votre agence vous suit partout dans le monde";
                message.Body = string.Format("IMOB+ est heureux de vous compter parmir les clients de l'agence. Veillez confirmer votre demande en cliquant sur le bouton suivant");
                message.IsBodyHtml = true;

                //configuration smtp

                using (var smtp = new SmtpClient())
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    var credential = new NetworkCredential
                    {
                        UserName = "at193542@gmail.com",
                        Password = "ta0610ami"
                    };
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    await smtp.SendMailAsync(message);

                    return View("Investir", Inves);
                }*/
            }

            return View("Investir");
        }

    }
}