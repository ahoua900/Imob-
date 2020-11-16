using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ImobPlus.Models
{
    public class Construire
    {
        [Key]
        public int MyProperty { get; set; }
        public string NameConst { get; set; }
        public string TypeConst { get; set; }
        public string EmailConst { get; set; }
        public string MessageConst { get; set; }
        public string LieuConst { get; set; }
    }
}