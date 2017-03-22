using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class AdjustmentHistoryController : Controller
    {
        // GET: AdjustmentHistory
        public ActionResult Index(int id)
        {
            return View(TrxAdjustmentHistoryRepo.GetData(id));
        }

        public ActionResult Create()
        {

            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(TrxAdjustmentHistoryViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                if (TrxAdjustmentHistoryRepo.Add(IsiData))
                {
                    return RedirectToAction("index");
                }
            }

            return PartialView("Create", IsiData);
        }

        public ActionResult Edit(int id)
        {
            TrxAdjustmentHistoryViewModel model = TrxAdjustmentHistoryRepo.CariID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(TrxAdjustmentHistoryViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (TrxAdjustmentHistoryRepo.Update(data))
                {
                    return RedirectToAction("index");
                }

            }
            return PartialView("Edit", data);
        }

        public ActionResult Details(int id)
        {
            TrxAdjustmentHistoryViewModel model = TrxAdjustmentHistoryRepo.CariID(id);
            return PartialView("Details", model);
        }

        public ActionResult Delete(int id)
        {
            TrxAdjustmentHistoryViewModel model = TrxAdjustmentHistoryRepo.CariID(id);
            return PartialView("Delete", model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOutlet(TrxAdjustmentHistoryViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (TrxAdjustmentHistoryRepo.Delete(data))
                {
                    return RedirectToAction("index");
                }
            }
            return View("index");
        }
    }
}