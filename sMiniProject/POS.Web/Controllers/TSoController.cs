using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class TSoController : Controller
    {
        // GET: TSo
        public ActionResult Index()
        {
            return View (TrxTsoRepo.GetData());
        }

        //-----------script tambah data------------
        public ActionResult Create()
        {
            return PartialView("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrxTSoViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (TrxTsoRepo.Tambah(mdl))
                {
                    return RedirectToAction("Index");
                }
            }


            return PartialView("Index", mdl);
        }

        //-----------script edit data------------
        public ActionResult Edit(int id)
        {
            TrxTSoViewModel model = TrxTsoRepo.CariBerdasarkanId(id);
            return PartialView("Edit", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TrxTSoViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (TrxTsoRepo.Update(mdl))
                {
                    return RedirectToAction("Index");
                }

            }
            return View("Edit", mdl);
        }

        //-----------script hapus data------------
        public ActionResult Delete(int id)
        {
            TrxTSoViewModel model = TrxTsoRepo.CariBerdasarkanId(id);
            return PartialView("Delete", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TrxTSoViewModel mdl)
        {

            // TrxTSoRepo.Hapus(mdl);

            if (ModelState.IsValid)
            {
                if (TrxTsoRepo.Hapus(mdl))
                {
                    return RedirectToAction("index");
                }
            }


            return View("Index");
        }

    }
}