using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class PrHistoryController : Controller
    {
        // GET: PrHistory
        public ActionResult Index()
        {
            return View(TrxPrHistoryRepo.GetData());
        }

        public ActionResult Create()
        {

            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(TrxPrHistoryViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                if (TrxPrHistoryRepo.Add(IsiData))
                {
                    return RedirectToAction("index");
                }
            }

            return PartialView("Create", IsiData);
        }

        public ActionResult Edit(int id)
        {
            TrxPrHistoryViewModel model = TrxPrHistoryRepo.CariID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(TrxPrHistoryViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (TrxPrHistoryRepo.Update(data))
                {
                    return RedirectToAction("index");
                }

            }
            return PartialView("Edit", data);
        }



        public ActionResult Delete(int id)
        {
            TrxPrHistoryViewModel model = TrxPrHistoryRepo.CariID(id);
            return PartialView("Delete", model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOutlet(TrxPrHistoryViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (TrxPrHistoryRepo.Delete(data))
                {
                    return RedirectToAction("index");
                }
            }
            return View("index");
        }
    }
}