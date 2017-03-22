using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class TransferStockController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {

            return View(TrxTransferStockRepo.GetData());
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(TrxTransferStockViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (TrxTransferStockRepo.Tambah(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Create", model);
        }

        public ActionResult Edit(int id)
        {
            TrxTransferStockViewModel model = TrxTransferStockRepo.CariBerdasarkanID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(TrxTransferStockViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (TrxTransferStockRepo.Update(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Update", model);
        }

        public ActionResult Delete(int id)
        {
            TrxTransferStockViewModel model = TrxTransferStockRepo.CariBerdasarkanID(id);
            return PartialView("Delete", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(TrxTransferStockViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (TrxTransferStockRepo.Hapus(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Index");
        }


        public ActionResult Details(int id)
        {
            TrxTransferStockViewModel model = TrxTransferStockRepo.CariBerdasarkanID(id);
            return PartialView("Details", model);
        }
    }
}