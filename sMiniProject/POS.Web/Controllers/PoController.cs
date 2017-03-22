using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class PoController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {

            return View(TrxPoRepo.GetData());
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(TrxPoViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (TrxPoRepo.Tambah(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Create", model);
        }

        public ActionResult Edit(int id)
        {
            TrxPoViewModel model = TrxPoRepo.CariBerdasarkanID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(TrxPoViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (TrxPoRepo.Update(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Update", model);
        }

        public ActionResult Delete(int id)
        {
            TrxPoViewModel model = TrxPoRepo.CariBerdasarkanID(id);
            return PartialView("Delete", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(TrxPoViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (TrxPoRepo.Hapus(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Index");
        }


        public ActionResult Details(int id)
        {
            TrxPoViewModel model = TrxPoRepo.CariBerdasarkanID(id);
            return PartialView("Details", model);
        }
    }
}