using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.ViewModel;
using POS.Repo;

namespace POS.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View(MstUserRepo.GetData());
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MstUserViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (MstUserRepo.Tambah(mdl))
                {
                    return RedirectToAction("Index");
                }
            }


            return PartialView("Index", mdl);
        }

        //-----------script edit data------------
        public ActionResult Edit(int id)
        {
            MstUserViewModel model = MstUserRepo.CariBerdasarkanId(id);
            return PartialView("Edit", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MstUserViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (MstUserRepo.Update(mdl))
                {
                    return RedirectToAction("Index");
                }

            }
            return View("Edit", mdl);
        }

        //-----------script hapus data------------
        public ActionResult Delete(int id)
        {
            MstUserViewModel model = MstUserRepo.CariBerdasarkanId(id);
            return PartialView("Delete", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MstUserViewModel mdl)
        {

            // MstUserRepo.Hapus(mdl);

            if (ModelState.IsValid)
            {
                if (MstUserRepo.Hapus(mdl))
                {
                    return RedirectToAction("index");
                }
            }


            return View("Index");
        }

    }
}