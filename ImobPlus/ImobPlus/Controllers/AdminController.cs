using System;
using System.Collections.Generic;
using ImobPlus.Models;
using ImobPlus.DAL;
using System.Linq;
using System.IO;
using ImobPlus.ViewModels;
using System.Web;
using System.Web.Mvc;

namespace ImobPlus.Controllers
{
    public class AdminController : Controller
    {
        // Partie Alex 
        private ImobDbContext _ctx;

        public AdminController()
        {
            _ctx = new ImobDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }


        public ActionResult Admin()
        {
            var res = _ctx.Posts.ToList();
            return View(res);
        }

        public ActionResult AddLocation()
        {          

            return View();
        }

        [HttpPost]
        public ActionResult AddLocation(Post post)
        {

            if (!ModelState.IsValid)
            {
                if (post.Id_Post == 0)
                {
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];
                        if (file != null && file.ContentLength > 0)//Vérifie que le fichier existe
                        {
                            var fileName = Path.GetFileName(file.FileName); //Récupération du nom du fichier
                            var ext = Path.GetExtension(fileName).ToLower();
                            if (ext == ".jpg" || ext == ".png" || ext == ".jpeg" || ext == ".gif")
                            {
                                var path = Path.Combine(Server.MapPath("/Fichier"), fileName);//Enregistrement du fichier dans le dossier Fichier
                                file.SaveAs(path);
                                post.Img_Post = fileName;
                            }
                        }
                    }
                    _ctx.Posts.Add(post);
                    _ctx.SaveChanges();
                }
                else
                {
                    var postInDb = _ctx.Posts.Single(c => c.Id_Post == post.Id_Post);
                    postInDb.Type = post.Type;
                    postInDb.Choix = post.Choix;
                    postInDb.Name_Bailleur = post.Name_Bailleur;
                    postInDb.Contact_Bailleur = post.Contact_Bailleur;
                    postInDb.Email_Bailleur = post.Email_Bailleur;
                    postInDb.nbre_Chambres = post.nbre_Chambres;
                    postInDb.nbre_Cuisines = post.nbre_Cuisines;
                    postInDb.nbre_Douches = post.nbre_Douches;
                    postInDb.Location = post.Location;
                    postInDb.Describe = post.Describe;
                    postInDb.Mini_Describe = post.Mini_Describe;
                    postInDb.Price = post.Price;
                    postInDb.Img_Post = post.Img_Post;

                    _ctx.Posts.Update(postInDb);
                    _ctx.SaveChanges();
                }
                
                return RedirectToAction("Admin", "Admin");
            }
            else
            {
                
                return View("AddLocation");
            }

        }
        public ActionResult EditPost(int id)
        {
            var post = _ctx.Posts.SingleOrDefault(x => x.Id_Post == id);
           
            return View("AddLocation",post);
        }
        //Partie Amy
        public ActionResult Demenager()
        {
            var context = new ImobDbContext();
            ViewBag.Demenager = context.Demenagements.ToList();
            return View();
        }

        //Partie Amy delete demenagement
        public ActionResult DeletePostDemenager(int id)
        {
            var context = new ImobDbContext();

            try
            {
                Demenagement demenager = context.Demenagements.Find(id);

                if (demenager != null)
                {
                    context.Demenagements.Remove(demenager);
                    context.SaveChanges();
                }
                return RedirectToAction("Demenager");
            }
            catch (Exception ex)
            {
                return HttpNotFound();
            }

        }

        //Partie Amy construire
        public ActionResult Construire()
        {
            var context = new ImobDbContext();
            ViewBag.Construire = context.Construires.ToList();
            return View();
        }
        //Partie Amy Construire delete
        public ActionResult DeletePostConstruire(int id)
        {
            var context = new ImobDbContext();

            try
            {
                Construire construi = context.Construires.Find(id);

                if (construi != null)
                {
                    context.Construires.Remove(construi);
                    context.SaveChanges();
                }
                return RedirectToAction("Construire");
            }
            catch (Exception ex)
            {
                return HttpNotFound();
            }

        }
        //Partie Amy investir
        public ActionResult Investir()
        {
            var context = new ImobDbContext();
            ViewBag.investir = context.Investirs.ToList();
            return View();
        }

        //Partie Amy delete investir
        public ActionResult DeletePost(int id)
        {
            var context = new ImobDbContext();

            try
            {
                Investir investir = context.Investirs.Find(id);

                if (investir != null)
                {
                    context.Investirs.Remove(investir);
                    context.SaveChanges();
                }
                return RedirectToAction("Investir");
            }
            catch (Exception ex)
            {
                return HttpNotFound();
            }

        }

        //Partie Olivier
        public ActionResult Contact()
        {
            var cteDb = new ImobDbContext();
            var dr = cteDb.Contacts.ToList();
            return View(dr);
        }

        // Partie Elvis
        public ActionResult Conseils()
        {
            var cteDb = new IndexViewModel();
            cteDb.Liconseils = GetLiconseils();
            cteDb.Conseillers = GetConseillers();

            return View(cteDb);
        }
        public List<Liconseil> GetLiconseils()
        {
            var cte = new ImobDbContext();
            var dr = cte.Liconseils.ToList();
            return dr;
        }
        public List<Conseiller> GetConseillers()
        {
            var cte = new ImobDbContext();
            var dr = cte.Conseillers.ToList();
            return dr;
        }
        // Partie Elvis
        public ActionResult AddConseiller()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult AddConseiller(Conseiller co)
        {
            var cteDb = new ImobDbContext();
            if (co.NomPrenom != null && co.Email != null && co.DIsponible != null && co.Contact != null)
            {
                if (co.Photo != null)
                {
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)//Vérifie que le fichier existe
                    {
                        var fileName = Path.GetFileName(file.FileName); //Récupération du nom du fichier
                        var ext = Path.GetExtension(fileName).ToLower();
                        if (ext == ".jpg" || ext == ".png" || ext == ".jpeg" || ext == ".gif")
                        {
                            var path = Path.Combine(Server.MapPath("/Fichier"), fileName);//Enregistrement du fichier dans le dossier Fichier
                            file.SaveAs(path);
                            co.Photo = fileName;
                            cteDb.Conseillers.Add(co);
                            cteDb.SaveChanges();
                            ViewBag.su = "Conseiller bien ajouté";
                        }else
                            ViewBag.erro = "Choississez une image s'il vous plait";
                    }
                }
                else
                    ViewBag.erro = "Choississez une image s'il vous plait";
            }else
                ViewBag.erro = "Veuillez remplir tous les champs s'il vous plait";
            return View();
        }
        public ActionResult DeleteConseiller(int id)
        {
            if (id != 0)
            {
                var db = new ImobDbContext();
                var dr = db.Conseillers.SingleOrDefault(s => s.Id == id);
                db.Conseillers.Remove(dr);
                db.SaveChanges();
                ViewBag.supe = "Conseiller supprimé ave succés";
            }
            return View("Conseils");
        }
        public ActionResult DeleteConseils(int id)
        {
            if (id != 0)
            {
                var db = new ImobDbContext();
                var dr = db.Liconseils.SingleOrDefault(s => s.Id_Liconseil == id);
                db.Liconseils.Remove(dr);
                db.SaveChanges();
                ViewBag.sup = "Conseils supprimé ave succés";
            }
            return View("Conseils");
        }
    }
}