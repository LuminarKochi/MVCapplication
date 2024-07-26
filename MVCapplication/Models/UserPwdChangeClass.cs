using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCapplication.Models
{
    public class UserPwdChangeClass
    {
        public string oldpassword { get; set;}
        [Required(ErrorMessage ="Enter the Password")]
        public string newpassword { get; set;}
        [Compare("newpassword", ErrorMessage = "Password and Confirm Password do not match")]
        public string confirmpassword { get; set; }
        public string msg { get; set; } //for message
    }
}