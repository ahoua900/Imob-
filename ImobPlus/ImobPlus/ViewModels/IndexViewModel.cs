using System;
using System.Collections.Generic;
using ImobPlus.Models;
using System.Linq;
using System.Web;

namespace ImobPlus.ViewModels
{
    public class IndexViewModel
    {
        public List<Conseiller> Conseillers {get;set;}
        public List<Liconseil> Liconseils { get; set; }
        public List<Post> Posts {get;set;}
    }
}