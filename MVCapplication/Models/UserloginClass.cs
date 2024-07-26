using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCapplication.Models
{
    public class UserloginClass
    {
        [Required(ErrorMessage = "Enter the Username")]
        public string Uname { get; set; }
        [Required(ErrorMessage ="Enter the Password")]
        public string password { get; set;}
        public string msg { get; set; } //for message
    }
}