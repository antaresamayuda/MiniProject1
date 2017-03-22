using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class ProvinceController : Controller
    {
        // GET: Province
        public ActionResult Index()
        {
            return View(MstProvinceRepo.GetData());
        }

        public ActionResult Create()
        {

            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MstProvinceViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MstProvinceRepo.Add(model))
                {
                    return RedirectToAction("Index");
                }

            }
            return PartialView("Index", model);
        }


        public ActionResult Edit(int id)
        {
            MstProvinceViewModel model = MstProvinceRepo.CariBerdasarkanId(id);
            return PartialView("Edit", model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MstProvinceViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (MstProvinceRepo.Update(mdl))
                {
                    return RedirectToAction("Index");
                }
            }

            return PartialView("Index");
        }

        public ActionResult Details(int id)
        {
            MstProvinceViewModel model = MstProvinceRepo.CariBerdasarkanId(id);
            return PartialView("Details", model);
        }

        public ActionResult Delete(int id)
        {
            MstProvinceViewModel model = MstProvinceRepo.CariBerdasarkanId(id);
            return PartialView("Details", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MstProvinceViewModel mdl)
        {
            if (ModelState.IsValid)
            {

                if (MstProvinceRepo.Delete(mdl))
                {
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }


    }
}