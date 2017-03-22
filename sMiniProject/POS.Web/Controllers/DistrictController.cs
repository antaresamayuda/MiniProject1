using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Model;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class DistrictController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View(MstDistrictRepo.Getdata());
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstDistrictViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                if (MstDistrictRepo.Add(IsiData))
                {
                    return RedirectToAction("index");
                }
            }

            return PartialView("Create", IsiData);
        }

        public ActionResult Edit(int id)
        {
            MstDistrictViewModel model = MstDistrictRepo.CariID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(MstDistrictViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstDistrictRepo.Update(data))
                {
                    return RedirectToAction("index");
                }

            }
            return PartialView("Edit", data);
        }



        public ActionResult Delete(int id)
        {
            MstDistrictViewModel model = MstDistrictRepo.CariID(id);
            return PartialView("Delete", model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAnggota(MstDistrictViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstDistrictRepo.Delete(data))
                {
                    return RedirectToAction("index");
                }
            }
            return View("index");
        }
    }
}