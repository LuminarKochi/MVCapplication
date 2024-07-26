using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCapplication.Models;

namespace MVCapplication.Controllers
{
    public class LoginDBController : Controller
    {
        MVCmainEntities dbobj = new MVCmainEntities();
        // GET: LoginDB
        public ActionResult Login_pageload()
        {
            return View();
        }

        public ActionResult Login_Click(UserloginClass objcls)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_login(objcls.Uname, objcls.password, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    Session["uname"] = objcls.Uname;
                    return RedirectToAction("Home");
                }
                else
                {
                    ModelState.Clear();
                    objcls.msg = "Invalid Username or Password";
                    return View("Login_pageload", objcls);
                }
            }
            return View("Login_pageload", objcls);
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}