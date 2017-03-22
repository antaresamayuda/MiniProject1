using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class PrController : Controller
    {
        // GET: Pr
        public ActionResult Index()
        {
            return View(MstPrRepo.GetData());
        }

        public ActionResult Create()
        {

            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MstPrViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (MstPrRepo.Add(model))
                {
                    return RedirectToAction("Index");
                }

            }
            return PartialView("Index", model);
        }


        public ActionResult Edit(int id)
        {
            MstPrViewModel model = MstPrRepo.CariBerdasarkanId(id);
            return PartialView("Edit", model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MstPrViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (MstPrRepo.Update(mdl))
                {
                    return RedirectToAction("Index");
                }
            }

            return PartialView("Index");
        }

        public ActionResult Details(int id)
        {
            MstPrViewModel model = MstPrRepo.CariBerdasarkanId(id);
            return PartialView("Details", model);
        }


        public ActionResult Delete(int id)
        {
            MstPrViewModel model = MstPrRepo.CariBerdasarkanId(id);
            return PartialView("Delete", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MstPrViewModel mdl)
        {
            if (ModelState.IsValid)
            {

                if (MstPrRepo.Delete(mdl))
                {
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }



    }
}