using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            return View(MstSupplierRepo.GetData());
        }

        //-----------script tambah data------------
        public ActionResult Search(string searchText)
        {
            return PartialView("DataSupplier", MstSupplierRepo.GetAllSearch(searchText));
        }
        public ActionResult Create()
        {
            ViewBag.ListProv = new SelectList(MstProvinceRepo.GetData(), "id", "name");
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstSupplierViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                if (MstSupplierRepo.Tambah(IsiData))
                {
                    return RedirectToAction("index");
                }
            }
            return PartialView("Create", IsiData);
        }

        //-----------script edit data------------
        public ActionResult Edit(int id)
        {
            ViewBag.ListProv = new SelectList(MstProvinceRepo.GetData(), "id", "name");
            MstSupplierViewModel model = MstSupplierRepo.CariBerdasarkanId(id);
            return PartialView("Edit", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MstSupplierViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (MstSupplierRepo.Update(mdl))
                {
                    return RedirectToAction("Index");
                }

            }
            return View("Edit", mdl);
        }

        //-----------script hapus data------------
        public ActionResult Delete(int id)
        {
            MstSupplierViewModel model = MstSupplierRepo.CariBerdasarkanId(id);
            return PartialView("Delete", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MstSupplierViewModel mdl)
        {

            // MstSupplierRepo.Hapus(mdl);

            if (ModelState.IsValid)
            {
                if (MstSupplierRepo.Hapus(mdl))
                {
                    return RedirectToAction("index");
                }
            }


            return View("Index");
        }

    }
}