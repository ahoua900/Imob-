using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ImobPlus.Models
{
    public class ContactPro
    {
        [Key]
        public int Id { get; set; }
        public string  Nom { get; set; }
        public string Bailleur { get; set; }
        public string EmailCont { get; set; }
        public string Message { get; set; }
    }
}