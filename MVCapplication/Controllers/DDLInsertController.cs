using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCapplication.Models;
namespace MVCapplication.Controllers
{
    public class DDLInsertController : Controller
    {
        MVCmainEntities dbobj = new MVCmainEntities();
        StateDistrictDB ddlcls = new StateDistrictDB();
        // GET: DDLInsert
        public ActionResult Insert_Pageload()
        {
            //dropdownlist
            List<stclass1> stList = ddlcls.Selectstates();
            ViewBag.Selstates = new SelectList(stList, "sId", "sName");
            return View();
        }
        public JsonResult GetDistricts(int stateId)
        {
            var districts = GetDistrictsByStateId(stateId);//Get districts by state ID
            return Json(districts, JsonRequestBehavior.AllowGet);
        }
        private List<SelectListItem> GetDistrictsByStateId(int stateId)
        {
            var getdistricts = ddlcls.Selectdistricts(stateId);
            var districtsbystate = getdistricts.Select(a => new SelectListItem() { Value = a.dId.ToString(), Text = a.dName }).ToList();
            return districtsbystate;
        }
        public ActionResult Insert_click(DDLClass clsobj,FormCollection form)
        {
            if (ModelState.IsValid)
            {
                List<stclass1> stList = ddlcls.Selectstates();
                int selectedId = Convert.ToInt32(form["sId"]);
                stclass1 selectedItem = stList.FirstOrDefault(c => c.sId == selectedId);
                clsobj.SId = selectedItem.sId;//set
                clsobj.SName = selectedItem.sName;//set
                ViewBag.Selstates = new SelectList(stList, "sId", "sName");

                int disId = Convert.ToInt32(form["DistrictId"]);
                clsobj.DId = disId;

                dbobj.sp_inserttab(clsobj.SId, clsobj.DId, clsobj.Name, clsobj.Age);
                clsobj.msg = "Successfully Inserted";
                return View("Insert_Pageload", clsobj);
            }
            else
            {
                List<stclass1> stList = ddlcls.Selectstates();
                ViewBag.Selstates = new SelectList(stList, "sId", "sName");
                return View("Insert_Pageload", clsobj);
            }
        }
    }
}