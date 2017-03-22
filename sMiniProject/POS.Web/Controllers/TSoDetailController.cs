using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.ViewModel;
using POS.Repo;

namespace POS.Web.Controllers
{
    public class TSoDetailController : Controller
    {
        // GET: TSoDetail
        public ActionResult Index()
        {
            return View(TrxTSoDetailRepo.GetData());
        }

        //-----------script tambah data------------
        public ActionResult Create()
        {
            return PartialView("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrxTSoDetailViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (TrxTSoDetailRepo.Tambah(mdl))
                {
                    return RedirectToAction("Index");
                }
            }


            return PartialView("Index", mdl);
        }

        //-----------script edit data------------
        public ActionResult Edit(int id)
        {
            TrxTSoDetailViewModel model = TrxTSoDetailRepo.CariBerdasarkanId(id);
            return PartialView("Edit", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TrxTSoDetailViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (TrxTSoDetailRepo.Update(mdl))
                {
                    return RedirectToAction("Index");
                }

            }
            return View("Edit", mdl);
        }

        //-----------script hapus data------------
        public ActionResult Delete(int id)
        {
            TrxTSoDetailViewModel model = TrxTSoDetailRepo.CariBerdasarkanId(id);
            return PartialView("Delete", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TrxTSoDetailViewModel mdl)
        {

            // TrxTSoDetailRepo.Hapus(mdl);

            if (ModelState.IsValid)
            {
                if (TrxTSoDetailRepo.Hapus(mdl))
                {
                    return RedirectToAction("index");
                }
            }


            return View("Index");
        }
    }
}