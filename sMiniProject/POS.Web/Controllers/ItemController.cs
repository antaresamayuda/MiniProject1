using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult AddItemAdjust()
        {

            return PartialView(MstItemRepo.GetDataItem());
        }

        public ActionResult Index()
        {

            return View(MstItemRepo.GetData());
        }

        public ActionResult Search(string searchText)
        {
            return PartialView("DataItem", MstItemRepo.GetAllSearch(searchText));
        }
       

        public ActionResult DataCategory(int id)
        {
            return PartialView("DataCategory", MstItemRepo.GetCategory(id));
        }

        public ActionResult DataInStock(int id)
        {
            return PartialView("DataInStock", MstItemRepo.GetInStock(id));
        }

        public ActionResult DataAlertStock(int id)
        {
            return PartialView("DataAlertStock", MstItemRepo.GetAlertStock(id));
        }

        public ActionResult Create()
        {
            ViewBag.ListProv = new SelectList(MstCategoryRepo.Getdata(), "id", "name");
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                // save ke header
                POS.Model.POSContext context = new Model.POSContext();
                if (Repo.MstItemRepo.InsertData(context, model))
                {
                    return RedirectToAction("Index");
                }
                else
                    ModelState.AddModelError("", "Gagal simpan ke Database");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ListProv = new SelectList(MstCategoryRepo.Getdata(), "id", "name");
            MstItemViewModel model = MstItemRepo.CariBerdasarkanID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(MstItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MstItemRepo.Update(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Index", model);
        }

        public ActionResult EditVr(int id)
        {
            DTVariants model = MstItemRepo.CariVariantbyID(id);
            return PartialView("EditVr", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult EditVr(DTVariants model)
        {
            if (ModelState.IsValid)
            {
                if (MstItemRepo.UpdateVariant(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Index", model);
        }

        public ActionResult Delete(int id)
        {
            MstItemViewModel model = MstItemRepo.CariBerdasarkanID(id);
            return PartialView("Delete", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(MstItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MstItemRepo.Hapus(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Index");
        }


        public ActionResult Details(int id)
        {
            MstItemViewModel model = MstItemRepo.CariBerdasarkanID(id);
            return PartialView("Details", model);
        }

    }
}