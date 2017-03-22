using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class ItemVariantController : Controller
    {
        // GET: ItemVariant
        public ActionResult Index()
        {

            return View(MstItemVariantRepo.GetData());
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstItemVariantViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MstItemVariantRepo.Tambah(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Create", model);
        }

        public ActionResult Edit(int id)
        {
            MstItemVariantViewModel model = MstItemVariantRepo.CariBerdasarkanID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(MstItemVariantViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MstItemVariantRepo.Update(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Update", model);
        }

        public ActionResult Delete(int id)
        {
            MstItemVariantViewModel model = MstItemVariantRepo.CariBerdasarkanID(id);
            return PartialView("Delete", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(MstItemVariantViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MstItemVariantRepo.Hapus(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Index");
        }


        public ActionResult Details(int id)
        {
            MstItemVariantViewModel model = MstItemVariantRepo.CariBerdasarkanID(id);
            return PartialView("Details", model);
        }
    }
}