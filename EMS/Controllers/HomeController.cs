using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Controllers
{
    public class HomeController : Controller
    {
        EMSeVidenceExamEntities db = new EMSeVidenceExamEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult searchEmployee()
        {
            ViewBag.Chars = Enumerable.Range(65, 26).Select(n=>(char)n).ToList();
            return View();
        }
        public PartialViewResult srEmployee(string start="")
        {
            List<tblEpersonla> modelData;
            if (string.IsNullOrEmpty(start))
            {
                modelData = db.tblEpersonlas.ToList();
            }
            else
            {
                modelData = db.tblEpersonlas.Where(c => c.eName.ToLower().StartsWith(start.ToLower())).ToList();
            }
            return PartialView("_srEmployee",modelData);
        }
        public PartialViewResult EpmName(string Name = "")
        {
            List<tblEpersonla> modelData;
            if (string.IsNullOrEmpty(Name))
            {
                modelData = db.tblEpersonlas.ToList();
            }
            else
            {
                modelData = db.tblEpersonlas.Where(c => c.ePhoneNo.Equals(Name)).ToList();

            }
            return PartialView("_srEmployee", modelData);
        }
    }
}