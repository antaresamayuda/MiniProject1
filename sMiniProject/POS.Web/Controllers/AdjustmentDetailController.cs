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
    public class AdjustmentDetailController : Controller
    {
        // GET: Category
        public ActionResult Index(int id)
        {
            return View(TrxAdjustmentDetailRepo.Getdata(id));
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(TrxAdjustmentDetailViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                if (TrxAdjustmentDetailRepo.Add(IsiData))
                {
                    return RedirectToAction("index");
                }
            }

            return PartialView("Create", IsiData);
        }

        public ActionResult Edit(int id)
        {
            TrxAdjustmentDetailViewModel model = TrxAdjustmentDetailRepo.CariID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(TrxAdjustmentDetailViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (TrxAdjustmentDetailRepo.Update(data))
                {
                    return RedirectToAction("index");
                }

            }
            return PartialView("Edit", data);
        }

        public ActionResult List(int id)
        {
            return PartialView(TrxAdjustmentDetailRepo.Getdata(id));
        }

        public ActionResult Details(int id)
        {
            TrxAdjustmentDetailViewModel model = TrxAdjustmentDetailRepo.CariID(id);
            return PartialView("Details", model);
        }

        public ActionResult Delete(int id)
        {
            TrxAdjustmentDetailViewModel model = TrxAdjustmentDetailRepo.CariID(id);
            return PartialView("Delete", model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAnggota(TrxAdjustmentDetailViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (TrxAdjustmentDetailRepo.Delete(data))
                {
                    return RedirectToAction("index");
                }
            }
            return View("index");
        }
    }
}