using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Repo;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult List()
        {
            return PartialView(MstEmployeeRepo.GetData());
        }

        public ActionResult NameOutletMODAL(int id)
        {
            return PartialView("_OutletMODAL",MstEmployeeRepo.GetNameOutlet(id));
        }

        public ActionResult Search(string searchText)
        {
            return PartialView("List", MstEmployeeRepo.GetAllSearch(searchText));
        }

        public ActionResult AmbilOutlet(int id)
        {
            return PartialView("AmbilOutlet",MstEmployeeRepo.GetAll(id));
        }

        public ActionResult AmbilRole(int id)
        {
            return PartialView("AmbilRole", MstEmployeeRepo.GetRole(id));
        }

        public string ContribType { get; set; }

        public ActionResult Index()
        {
            ViewBag.ListRole = new SelectList(MstRoleRepo.GetData(), "id", "name");
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MstEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                // save ke header
                POS.Model.POSContext context = new Model.POSContext();
                if (Repo.MstEmployeeRepo.InsertData(context, model))
                {
                    return RedirectToAction("Index");
                }
                else
                    ModelState.AddModelError("", "Gagal simpan ke Database");
            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            ViewBag.ListRole = new SelectList(MstRoleRepo.GetData(), "id", "name");
            MstEmployeeViewModel model = MstEmployeeRepo.CariBerdasarkanId(id);
            return PartialView("Edit", model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MstEmployeeViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (MstEmployeeRepo.Update(mdl))
                {
                    return RedirectToAction("Index");
                }
            }

            return PartialView("Index");
        }


        public ActionResult Forgot()
        {
            return PartialView("Forgot");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Forgot(MstEmployeeViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (MstEmployeeRepo.UpdatePassword(mdl))
                {
                    Session["scs"] = "Success";
                    return RedirectToAction("Login","Login");
                }
            }

            return PartialView("Login","Login");
        }


        public ActionResult Details(int id)
        {
            MstEmployeeViewModel model = MstEmployeeRepo.CariBerdasarkanId(id);
            return PartialView("Details",model);
        }



        public ActionResult Delete(int id)
        {
            MstEmployeeViewModel model = MstEmployeeRepo.CariBerdasarkanId(id);
            return PartialView("Delete", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MstEmployeeViewModel mdl)
        {
            if (ModelState.IsValid)
            {

                if (MstEmployeeRepo.Delete(mdl))
                {
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }

        public ActionResult Aktifkan(int id)
        {
            MstEmployeeViewModel model = MstEmployeeRepo.CariBerdasarkanId(id);
            return PartialView("Aktifkan", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Aktifkan(MstEmployeeViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (MstEmployeeRepo.Aktifkan(mdl))
                {
                    return RedirectToAction("Index");
                }
            }

            return PartialView("Index");
        }


        public ActionResult NonAct(int id)
        {
            MstEmployeeViewModel model = MstEmployeeRepo.CariBerdasarkanId(id);
            return PartialView("NonAct", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NonAct(MstEmployeeViewModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (MstEmployeeRepo.NonAct(mdl))
                {
                    return RedirectToAction("Index");
                }
            }

            return PartialView("Index");
        }
    }
}