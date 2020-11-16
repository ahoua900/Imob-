using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ImobPlus.Models
{
    public class Liconseil
    {
        [Key]
        public int Id_Liconseil { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public string NomPrenom { get; set; }
    }
}