using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;

namespace POS.Web.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOutletById(int id)
        {
            return PartialView("_RowOutlet", Repo.MstOutletRepo.GetDataById(id));
        }

        public ActionResult GetDataProvKota(int id)
        {
            return Json(MstRegionRepo.ProvRegion(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataKotaKec(int id)
        {
            return Json(MstDistrictRepo.RegionDistrict(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCategoryID(int id)
        {
            return Json(MstCategoryRepo.GetDataByID(id), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCategory()
        {
            return Json(MstCategoryRepo.Getdata(), JsonRequestBehavior.AllowGet);
        }
    }
}