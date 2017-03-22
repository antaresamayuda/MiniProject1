using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class ItemInventoryController : Controller
    {
        // GET: ItemInventory
        public ActionResult Index()
        {
            return View(MstItemInventoryRepo.GetData());
        }

        public ActionResult Create()
        {

            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstItemInventoryViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                if (MstItemInventoryRepo.Add(IsiData))
                {
                    return RedirectToAction("index");
                }
            }

            return PartialView("Create", IsiData);
        }

        public ActionResult Edit(int id)
        {
            MstItemInventoryViewModel model = MstItemInventoryRepo.CariID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(MstItemInventoryViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstItemInventoryRepo.Update(data))
                {
                    return RedirectToAction("index");
                }

            }
            return PartialView("Edit", data);
        }



        public ActionResult Delete(int id)
        {
            MstItemInventoryViewModel model = MstItemInventoryRepo.CariID(id);
            return PartialView("Delete", model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteKecamatan(MstItemInventoryViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstItemInventoryRepo.Delete(data))
                {
                    return RedirectToAction("index");
                }
            }
            return View("index");
        }
    }
}