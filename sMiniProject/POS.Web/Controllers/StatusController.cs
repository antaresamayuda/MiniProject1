using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class StatusController : Controller
    {
        // GET: Status
        public ActionResult Index()
        {
            return View(MstStatusRepo.GetData());
        }

        public ActionResult Create()
        {

            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstStatusViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                if (MstStatusRepo.Add(IsiData))
                {
                    return RedirectToAction("index");
                }
            }

            return PartialView("Create", IsiData);
        }

        public ActionResult Edit(int id)
        {
            MstStatusViewModel model = MstStatusRepo.CariID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(MstStatusViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstStatusRepo.Update(data))
                {
                    return RedirectToAction("index");
                }

            }
            return PartialView("Edit", data);
        }



        public ActionResult Delete(int id)
        {
            MstStatusViewModel model = MstStatusRepo.CariID(id);
            return PartialView("Delete", model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOutlet(MstStatusViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstStatusRepo.Delete(data))
                {
                    return RedirectToAction("index");
                }
            }
            return View("index");
        }
    }
}