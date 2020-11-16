using System;
using System.Collections.Generic;
using ImobPlus.Models;
using ImobPlus.DAL;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImobPlus.Controllers
{
    public class ConseilsController : Controller
    {
        // GET: Conseils
        public ActionResult IndexConseils()
        {
            var context = new ImobDbContext();
            var tout = context.Conseillers.ToList();
            var fine = tout.Count();
            
            if (fine != 0)
            {  
                return View(tout);
            }
            else
            {
                ViewBag.non = "Pas de conseiller disponible veuillez patienter";
                return View();
            }
        }
        public ActionResult LigneConseil()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LigneConseil(Liconseil liconseil)
        {
            var context = new ImobDbContext();
            if (liconseil.Email != null && liconseil.Message != null && liconseil.NomPrenom != null)
            {
                context.Liconseils.Add(liconseil);
                context.SaveChanges();
                ViewBag.succes = "Votre message a été prit en compte vous serrez contactez par un agent de IMOB+ dans un instant";
            }
            return View();
        }
    }
}