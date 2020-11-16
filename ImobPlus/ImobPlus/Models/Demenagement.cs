using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ImobPlus.Models
{
    public class Demenagement
    {
        [Key]
        public int Id { get; set; }
        public string NameDem { get; set; }
        public string EmailDem { get; set; }
        public string LieuDepartDem { get; set; }
        public string DestinaDem { get; set; }
        public string MessagDem { get; set; }
    }
}