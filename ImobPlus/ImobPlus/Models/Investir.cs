using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ImobPlus.Models
{
    public class Investir
    {
        [Key]
        public int Id { get; set; }
        public string NameInvest { get; set; }
        public string EmailInvest { get; set; }
        public string MessageInvest { get; set; }
        public string TypeInvest { get; set; }
    }
}