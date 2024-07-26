using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCapplication.Models
{
    public class stclass1
    { 
        public int sId { get; set; }
        public string sName { get; set; }
    }
    public class dtclass
    {
        public int dId { get; set; }
        public string dName { get; set; }
    }

    public class DDLClass
    {
        public int SId { get; set;}
        public string SName { get; set; } // this is for student
        public int DId { get; set; } // this is for department
        public string DName { get; set; } // this is for department
        [Required(ErrorMessage ="Enter the Name")]
        public string Name { get; set; } // this is for name
        [Range(18,50,ErrorMessage ="Enter the Age")]
        public int Age { get; set; } // this is for age
        public string msg { get; set; }
    }
}