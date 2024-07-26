using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCapplication.Models;
namespace MVCapplication.Controllers
{
    public class ProfileViewEditController : Controller
    {
        MVCmainEntities dbobj = new MVCmainEntities();
        // GET: ProfileViewEdit
        public ActionResult Profile_Load()
        {
            var getdata = dbobj.sp_profile(Session["uname"].ToString()).FirstOrDefault();
            return View(new UserProfileClass
            { 
                name=getdata.Name,
                age=getdata.Age,
                address=getdata.Address,
                email=getdata.Email,
                photo=getdata.Photo
            }
                );
        }
        public ActionResult Profile_Update(UserProfileClass obj)
        {
            dbobj.sp_profile_Update(Session["uname"].ToString(), obj.age, obj.address);
            obj.msg = "Successfully Updated";
            var getdata = dbobj.sp_profile(Session["uname"].ToString()).FirstOrDefault();
            return View("Profile_Load",new UserProfileClass
            {
                name = getdata.Name,
                age = getdata.Age,
                address = getdata.Address,
                email = getdata.Email,
                photo = getdata.Photo
            }
                );
        }
    }
}