using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImobPlus.Models
{
    public class Conseiller
    {
        [Key]
        public int Id { get; set; }
        public string NomPrenom { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Apropos { get; set; }
        public string Photo { get; set; }
        public string DIsponible { get; set; }
    }
}