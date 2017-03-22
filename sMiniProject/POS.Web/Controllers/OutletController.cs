using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class OutletController : Controller
    {
        // GET: Outlet
        public ActionResult Index()
        {
            return View(MstOutletRepo.GetData());
        }

        public ActionResult DataOutlet()
        {
            return PartialView(MstOutletRepo.GetData());
        }

        public ActionResult Search(string searchText)
        {
            return PartialView("DataOutlet", MstOutletRepo.GetAllSearch(searchText));
        }

        public ActionResult SearchIndex(string searchText)
        {
            return PartialView("DataOutletIndex", MstOutletRepo.GetSearchIndex(searchText));
        }

        public ActionResult Create()
        {
            ViewBag.ListProv = new SelectList(MstProvinceRepo.GetData(), "id", "name");
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstOutletViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                if (MstOutletRepo.Add(IsiData))
                {
                    return RedirectToAction("index");
                }
            }

            return PartialView("Create", IsiData);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ListProv = new SelectList(MstProvinceRepo.GetData(), "id", "name");
            MstOutletViewModel model = MstOutletRepo.CariID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(MstOutletViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstOutletRepo.Update(data))
                {
                    return RedirectToAction("index");
                }

            }
            return PartialView("Edit", data);
        }



        public ActionResult Delete(int id)
        {
            MstOutletViewModel model = MstOutletRepo.CariID(id);
            return PartialView("Delete", model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOutlet(MstOutletViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstOutletRepo.Delete(data))
                {
                    return RedirectToAction("index");
                }
            }
            return View("index");
        }
    }
}