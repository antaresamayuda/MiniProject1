using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class TransferStockHistoryController : Controller
    {
        // GET: TransferStockHistory
        public ActionResult Index()
        {
            return View(TrxTransferStockHistoryRepo.GetData());
        }

        public ActionResult Create()
        {

            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(TrxTransferStockHistoryViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                if (TrxTransferStockHistoryRepo.Add(IsiData))
                {
                    return RedirectToAction("index");
                }
            }

            return PartialView("Create", IsiData);
        }

        public ActionResult Edit(int id)
        {
            TrxTransferStockHistoryViewModel model = TrxTransferStockHistoryRepo.CariID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(TrxTransferStockHistoryViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (TrxTransferStockHistoryRepo.Update(data))
                {
                    return RedirectToAction("index");
                }

            }
            return PartialView("Edit", data);
        }



        public ActionResult Delete(int id)
        {
            TrxTransferStockHistoryViewModel model = TrxTransferStockHistoryRepo.CariID(id);
            return PartialView("Delete", model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOutlet(TrxTransferStockHistoryViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (TrxTransferStockHistoryRepo.Delete(data))
                {
                    return RedirectToAction("index");
                }
            }
            return View("index");
        }
    }
}