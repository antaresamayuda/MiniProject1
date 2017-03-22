using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class RegionController : Controller
    {
        // GET: Region
        public ActionResult Index()
        {
            return View(MstRegionRepo.GetData());
        }

        public ActionResult Create()
        {
            
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MstRegionViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MstRegionRepo.Add(model))
                {
                    return RedirectToAction("Index");
                }

            }
            return PartialView("Index", model);
        }


        public ActionResult Edit(int id)
        {
            MstRegionViewModel model = MstRegionRepo.CariBerdasarkanId(id);
            return PartialView("Edit", model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MstRegionViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (MstRegionRepo.Update(mdl))
                {
                    return RedirectToAction("Index");
                }
            }

            return PartialView("Index");
        }

        public ActionResult Details(int id)
        {
            MstRegionViewModel model = MstRegionRepo.CariBerdasarkanId(id);
            return PartialView("Details", model);
        }

        public ActionResult Delete(int id)
        {
            MstRegionViewModel model = MstRegionRepo.CariBerdasarkanId(id);
            return PartialView("Delete", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MstRegionViewModel mdl)
        {
            if (ModelState.IsValid)
            {

                if (MstRegionRepo.Delete(mdl))
                {
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }

    }
}