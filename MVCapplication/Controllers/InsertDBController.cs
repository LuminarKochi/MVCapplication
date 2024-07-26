using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCapplication.Controllers;
using MVCapplication.Models;

namespace MVCapplication.Controllers
{
    public class InsertDBController : Controller
    {
        MVCmainEntities dbobj = new MVCmainEntities();
        // GET: InsertDB
        public ActionResult Insert_Pageload()
        {
            //dropdownlist
            List<stClass> sList = new List<stClass>
            {
                new stClass{sId=1,sName="Kerala"},
                new stClass{sId=2,sName="Tamil Nadu" },
                new stClass{sId=3,sName="Karnataka" }
            };
            ViewBag.Selstates = new SelectList(sList, "sId", "sName");

            //checkboxlist
            UserInsertClass user = new UserInsertClass();
            user.MyFavoriteQual = getQualificationData();
            return View(user);
        }
        public List<CheckBoxListHelper> getQualificationData()
        {
            List<CheckBoxListHelper> sts = new List<CheckBoxListHelper>()
            {
                new CheckBoxListHelper { Value = "SSLC", Text = "SSLC", IsChecked = true },
                new CheckBoxListHelper { Value = "Plus Two", Text = "Plus Two", IsChecked = false },
                new CheckBoxListHelper { Value = "Degree", Text = "Degree", IsChecked = false },
                new CheckBoxListHelper { Value = "Post Graduate", Text = "Post Graduate", IsChecked = false },
                new CheckBoxListHelper { Value = "PhD", Text = "PhD", IsChecked = false }
            };
            return sts;
        }
        public ActionResult Insert_Click(UserInsertClass clsobj,HttpPostedFileBase file,FormCollection form)
        {
            if(ModelState.IsValid)
            {
                if(file.ContentLength>0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/PHS");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);

                    var fullpath = Path.Combine("~\\PHS", fname);
                    clsobj.photo = fullpath;//set
                }

                List<stClass> stList = new List<stClass>
                {
                    new stClass{sId=1,sName="Kerala" },
                    new stClass{sId=2,sName="Tamil Nadu" },
                    new stClass{sId=3,sName="Karnataka" }
                };
                ViewBag.Selstates = new SelectList(stList, "sId", "sName");

                int selectedId = Convert.ToInt32(form["ddlstates"]);
                stClass selectedItem = stList.FirstOrDefault(c => c.sId == selectedId);
                clsobj.sId = selectedItem.sId;//set
                clsobj.sName=selectedItem.sName;//set

                var quid = string.Join(",", clsobj.selectedQual);
                clsobj.qual = quid;//set
                clsobj.MyFavoriteQual = getQualificationData();

                dbobj.sp_reg_insert(clsobj.name, clsobj.age, clsobj.address, clsobj.email, clsobj.photo, clsobj.gen, clsobj.sName, clsobj.qual, clsobj.uname, clsobj.pwd);
                clsobj.msg = "Successfully Inserted";
                return View("Insert_Pageload", clsobj);
            }
            else
            {
                List<stClass> sList = new List<stClass>
            {
                new stClass{sId=1,sName="Kerala"},
                new stClass{sId=2,sName="Tamil Nadu" },
                new stClass{sId=3,sName="Karnataka" }
            };
                ViewBag.Selstates = new SelectList(sList, "sId", "sName");
                clsobj.MyFavoriteQual = getQualificationData();
                return View("Insert_Pageload", clsobj);
            }
        }

    }
}