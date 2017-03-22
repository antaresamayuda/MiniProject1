using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class TransferStockDetailController : Controller
    {
        // GET: TransferStockDetail
        public ActionResult Index()
        {
            return View(TrxTransferStockDetailRepo.GetData());
        }

        public ActionResult Create()
        {

            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(TrxTransferStockDetailViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                if (TrxTransferStockDetailRepo.Add(IsiData))
                {
                    return RedirectToAction("index");
                }
            }

            return PartialView("Create", IsiData);
        }

        public ActionResult Edit(int id)
        {
            TrxTransferStockDetailViewModel model = TrxTransferStockDetailRepo.CariID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(TrxTransferStockDetailViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (TrxTransferStockDetailRepo.Update(data))
                {
                    return RedirectToAction("index");
                }

            }
            return PartialView("Edit", data);
        }



        public ActionResult Delete(int id)
        {
            TrxTransferStockDetailViewModel model = TrxTransferStockDetailRepo.CariID(id);
            return PartialView("Delete", model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOutlet(TrxTransferStockDetailViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (TrxTransferStockDetailRepo.Delete(data))
                {
                    return RedirectToAction("index");
                }
            }
            return View("index");
        }
    }
}