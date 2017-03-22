using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            return View(MstRoleRepo.GetData());//
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MstRoleViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (MstRoleRepo.Tambah(mdl))
                {
                    return RedirectToAction("Index");
                }
            }


            return PartialView("Index", mdl);
        }

        //-----------script edit data------------
        public ActionResult Edit(int id)
        {
            MstRoleViewModel model = MstRoleRepo.CariBerdasarkanId(id);
            return PartialView("Edit", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MstRoleViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (MstRoleRepo.Update(mdl))
                {
                    return RedirectToAction("Index");
                }

            }
            return View("Edit", mdl);
        }

        //-----------script hapus data------------
        public ActionResult Delete(int id)
        {
            MstRoleViewModel model = MstRoleRepo.CariBerdasarkanId(id);
            return PartialView("Delete", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MstRoleViewModel mdl)
        {

            // MstRoleRepo.Hapus(mdl);

            if (ModelState.IsValid)
            {
                if (MstRoleRepo.Hapus(mdl))
                {
                    return RedirectToAction("index");
                }
            }


            return View("Index");
        }
    }
}