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
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View(MstCategoryRepo.Getdata());
        }

        public ActionResult Search(string searchText)
        {
            return PartialView("DataCategory", MstCategoryRepo.GetAllSearch(searchText));
        }

        public ActionResult CountItem(int id)
        {
            return PartialView("CountItem", MstCategoryRepo.GetCountItem(id));
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MstCategoryViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                if (MstCategoryRepo.Add(IsiData))
                {
                    return RedirectToAction("index");
                }
            }
            return PartialView("Create", IsiData);
        }

        public ActionResult Edit(int id)
        {
            MstCategoryViewModel model = MstCategoryRepo.CariID(id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(MstCategoryViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstCategoryRepo.Update(data))
                {
                    return RedirectToAction("index");
                }

            }
            return PartialView("Edit", data);
        }



        public ActionResult Delete(int id)
        {
            MstCategoryViewModel model = MstCategoryRepo.CariID(id);
            return PartialView("Delete", model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAnggota(MstCategoryViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (MstCategoryRepo.Delete(data))
                {
                    return RedirectToAction("index");
                }
            }
            return View("index");
        }
    }
}