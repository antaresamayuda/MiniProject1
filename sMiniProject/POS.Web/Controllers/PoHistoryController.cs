using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class PoHistoryController : Controller
    {
        // GET: PoHistory
        public ActionResult Index()
        {
            return View(TrxPoHistoryRepo.GetData());
        }

        public ActionResult Create()
        {

            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(TrxPoHistoryViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                if (TrxPoHistoryRepo.Add(IsiData))
                {
                    return RedirectToAction("index");
                }
            }

            return PartialView("Create", IsiData);
        }

        public ActionResult Edit(int id)
        {
            TrxPoHistoryViewModel model = TrxPoHistoryRepo.CariID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(TrxPoHistoryViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (TrxPoHistoryRepo.Update(data))
                {
                    return RedirectToAction("index");
                }

            }
            return PartialView("Edit", data);
        }



        public ActionResult Delete(int id)
        {
            TrxPoHistoryViewModel model = TrxPoHistoryRepo.CariID(id);
            return PartialView("Delete", model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOutlet(TrxPoHistoryViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (TrxPoHistoryRepo.Delete(data))
                {
                    return RedirectToAction("index");
                }
            }
            return View("index");
        }
    }
}