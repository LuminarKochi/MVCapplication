using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCapplication.Models
{
    public class stClass
    {
        public int sId { get; set; }
        public string sName { get; set; }
    }
    public class CheckBoxListHelper
    {
        public string Value { get; set;}
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }

    public class UserInsertClass
    {
        public int sId { get; set; }
        public string sName { get; set; }
        public List<CheckBoxListHelper> MyFavoriteQual { get; set;}
        public string[] selectedQual { get; set; }
        [Required(ErrorMessage = "**")]
        public string name { get; set; }
        [Range(18, 50, ErrorMessage = "Enter the Age")]
        public int age { get; set; }
        public string address { get; set; }
        [EmailAddress(ErrorMessage = "Enter valid email id")]
        public string email { get; set; }
        public string photo { get; set; }
        public string gen { get; set;}
        public string qual { get; set; }
        public string uname { get; set; }
        public string pwd { get; set; }
        [Compare("pwd", ErrorMessage = "Password and confirm password does not match")]
        public string cpwd { get; set; }
        public string msg { get; set; }

    }
}