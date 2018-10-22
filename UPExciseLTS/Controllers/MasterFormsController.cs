using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPExciseLTS.Models;
namespace UPExciseLTS.Controllers
{
    public class MasterFormsController : Controller
    {
        //
        // GET: /MasterForms/

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult BrandMaster()
        {
            List<SelectListItem> breweryList = new List<SelectListItem>();
            CMODataEntryBLL.bindDropDownHnGrid("proc_ddlDetail", breweryList, "BRE", "", "");
            BrandMaster Brand = new BrandMaster();
            ViewBag.Brewery = breweryList;
            return View(Brand);
        }
        [HttpPost]
        public ActionResult BrandMaster(BrandMaster B)
        {
            List<SelectListItem> breweryList = new List<SelectListItem>();
            CMODataEntryBLL.bindDropDownHnGrid("proc_ddlDetail", breweryList, "BRE", "", "");
            BrandMaster Brand = new BrandMaster();
            ViewBag.Brewery = breweryList;
            ViewData["Result"] = "Successfully";
            return View(Brand);
        }
        [HttpGet]
        public ActionResult BottelingPlan()
        {
            BottelingPlan Plan = new BottelingPlan();
            List<SelectListItem> BrandList = new List<SelectListItem>();
            CMODataEntryBLL.bindDropDownHnGrid_db2("proc_ddlDetail", BrandList, "BR", "", "");
            ViewBag.Brand = BrandList;
            return View(Plan);
        }
        [HttpGet]
        public ActionResult BottelingPlanList()
        {
            List<BottelingPlan> BPList = new List<BottelingPlan>();
            List<SelectListItem> BrandList = new List<SelectListItem>();
            CMODataEntryBLL.bindDropDownHnGrid_db2("proc_ddlDetail", BrandList, "BR", "", "");
            ViewBag.Brand = BrandList;
            return View(BPList);
        }

    }
}
