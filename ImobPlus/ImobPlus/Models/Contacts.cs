using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImobPlus.Models
{
    public class Contacts
    {
        [Key]
        public int Id_Contact { get; set; }
        public string  NomPrenom { get; set; }
        public string Email  { get; set; }
        public string Precoccupation { get; set; }
    }
}