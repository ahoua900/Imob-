using System;
using System.Collections.Generic;
using ImobPlus.DAL;
using ImobPlus.ViewModels;
using ImobPlus.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImobPlus.Controllers
{
    public class HomeController : Controller
    {
        ImobDbContext db = new ImobDbContext();
        public ActionResult Index()
        {
            var mode = new IndexViewModel();
            mode.Conseillers = GetConseil();
            mode.Posts = GetAchat();
            
            return View(mode);
        }

        private List<Post> GetAchat()
        {
            var dr = db.Posts.ToList();
            return dr;
        }

        private List<Conseiller> GetConseil()
        {
            var dr = db.Conseillers.ToList();
            return dr;
        }
    }
}