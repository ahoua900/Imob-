using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImobPlus.Models
{
    public class Post
    {
        [Key]
        public int Id_Post { get; set; }

        [Display(Name ="Localisation")]
        [Required(ErrorMessage ="Champs Requis")]
        public string Location { get; set; }


        [Required(ErrorMessage = "Champs Requis")]
        [Display(Name ="Mini Description")]
        public string Mini_Describe { get; set; }


        [Required(ErrorMessage = "Champs Requis")]
        [Display(Name = "Description du Bien")]
        public string Describe { get; set; }


        [Required(ErrorMessage = "Champs Requis")]
        [Display(Name = "Prix")]
        public string Price { get; set; }
        
        [Display(Name = "Image du Bien")]
        public string Img_Post { get; set; }


        [Required(ErrorMessage = "Champs Requis")]
        [Display(Name = "Nom du Propriétaire")]
        public string Name_Bailleur { get; set; }


        [Required(ErrorMessage = "Champs Requis")]
        [Display(Name = "Email")]
        public string Email_Bailleur { get; set; }


        [Required(ErrorMessage = "Champs Requis")]
        [Display(Name = "Contact")]
        public string Contact_Bailleur { get; set; }


        [Required(ErrorMessage = "Champs Requis")]
        [Display(Name = "Nombre de chambres")]
        public int nbre_Chambres { get; set; }


        [Required(ErrorMessage = "Champs Requis")]
        [Display(Name = "Nombre de douches")]
        public int nbre_Douches { get; set; }


        [Required(ErrorMessage = "Champs Requis")]
        [Display(Name = "Nombre de cuisines")]
        public int nbre_Cuisines { get; set; }
        public string  Choix { get; set; }
        public string  Type { get; set; }

        //Secondary Key 1

        /*[Display(Name ="Type de Bien")]
        public int Id_Type { get; set; }
        public virtual TypePost type { get; set; }

        //Secondary Key 2
       
        [Display(Name = "Choix")]
        public int Id_Choix { get; set; }
        public virtual ChoixPost choix { get; set; }*/
    }
}