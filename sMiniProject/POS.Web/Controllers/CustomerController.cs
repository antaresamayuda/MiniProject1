using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Model;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View(MstCustomerRepo.Getdata());
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstCustomerViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                if (MstCustomerRepo.Add(IsiData))
                {
                    return RedirectToAction("index");
                }
            }

            return PartialView("Create", IsiData);
        }

        public ActionResult Edit(int id)
        {
            MstCustomerViewModel model = MstCustomerRepo.CariID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(MstCustomerViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstCustomerRepo.Update(data))
                {
                    return RedirectToAction("index");
                }

            }
            return PartialView("Edit", data);
        }



        public ActionResult Delete(int id)
        {
            MstCustomerViewModel model = MstCustomerRepo.CariID(id);
            return PartialView("Delete", model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAnggota(MstCustomerViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstCustomerRepo.Delete(data))
                {
                    return RedirectToAction("index");
                }
            }
            return View("index");
        }
    }
}