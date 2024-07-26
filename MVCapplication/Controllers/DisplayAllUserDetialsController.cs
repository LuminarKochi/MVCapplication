using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCapplication.Models;
namespace MVCapplication.Controllers
{
    public class DisplayAllUserDetialsController : Controller
    {
        MVCmainEntities dbobj = new MVCmainEntities();
        // GET: DisplayAllUserDetials
        public ActionResult Display_Pageload()
        {
            var data = dbobj.sp_SelectAll().ToList();
            ViewBag.userdetails = data;
            return View();
        }
    }
}