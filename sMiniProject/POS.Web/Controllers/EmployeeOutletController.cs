using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class EmployeeOutletController : Controller
    {
        // GET: EmployeeOutlet
        public ActionResult Index()
        {

            return View(MstEmployeeOutletRepo.GetData());
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstEmployeeOutletViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MstEmployeeOutletRepo.Tambah(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Create", model);
        }

        public ActionResult Edit(int id)
        {
            MstEmployeeOutletViewModel model = MstEmployeeOutletRepo.CariBerdasarkanID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(MstEmployeeOutletViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MstEmployeeOutletRepo.Update(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Update", model);
        }

        public ActionResult Delete(int id)
        {
            MstEmployeeOutletViewModel model = MstEmployeeOutletRepo.CariBerdasarkanID(id);
            return PartialView("Delete", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(MstEmployeeOutletViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MstEmployeeOutletRepo.Hapus(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return PartialView("Index");
        }


        public ActionResult Details(int id)
        {
            MstEmployeeOutletViewModel model = MstEmployeeOutletRepo.CariBerdasarkanID(id);
            return PartialView("Details", model);
        }
    }
}