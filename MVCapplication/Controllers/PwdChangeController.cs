using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCapplication.Models;
namespace MVCapplication.Controllers
{
    public class PwdChangeController : Controller
    {
        MVCmainEntities dbobj = new MVCmainEntities();
        // GET: PwdChange
        public ActionResult Pwd_Load()
        {
            return View();
        }
        public ActionResult Pwd_click(UserPwdChangeClass clsobj)
        {
            if (ModelState.IsValid)
            {
                dbobj.sp_Pwdchange(Session["uname"].ToString(), clsobj.oldpassword, clsobj.newpassword);
                clsobj.msg = "Password changed successfully";
                return View("Pwd_Load", clsobj);
            }
            return View("Pwd_Load", clsobj);
        }
    }
}