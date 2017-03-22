using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class PurchaseDetailController : Controller
    {
        // GET: PurchaseDetail
        public ActionResult Index()
        {
            return View(MstPurchaseDetailRepo.GetData());
        }

        public ActionResult Create()
        {

            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MstPurchaseDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MstPurchaseDetailRepo.Add(model))
                {
                    return RedirectToAction("Index");
                }

            }
            return PartialView("Index", model);
        }


        public ActionResult Edit(int id)
        {
            MstPurchaseDetailViewModel model = MstPurchaseDetailRepo.CariBerdasarkanId(id);
            return PartialView("Edit", model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MstPurchaseDetailViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (MstPurchaseDetailRepo.Update(mdl))
                {
                    return RedirectToAction("Index");
                }
            }

            return PartialView("Index");
        }

        public ActionResult Details(int id)
        {
            MstPurchaseDetailViewModel model = MstPurchaseDetailRepo.CariBerdasarkanId(id);
            return PartialView("Details", model);
        }


        public ActionResult Delete(int id)
        {
            MstPurchaseDetailViewModel model = MstPurchaseDetailRepo.CariBerdasarkanId(id);
            return PartialView("Delete", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MstPurchaseDetailViewModel mdl)
        {
            if (ModelState.IsValid)
            {

                if (MstPurchaseDetailRepo.Delete(mdl))
                {
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }

    }
}