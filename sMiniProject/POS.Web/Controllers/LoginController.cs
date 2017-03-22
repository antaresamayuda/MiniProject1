using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Model;
using POS.ViewModel;
using POS.Repo;

namespace POS.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(MstUserViewModel objUser)
        {
            if (ModelState.IsValid)
            {
                using (POSContext db = new POSContext())
                {
                    var obj = db.MstUsers.Where(a => a.username.Equals(objUser.username) && a.password.Equals(objUser.password) && a.active==true).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.id.ToString();
                        Session["UserName"] = obj.username.ToString();
                        Session["RoleID"] = obj.roleId;
                        Session["EmployeeID"] = obj.employeeId;
                        objUser.roleId = obj.roleId;
                        objUser.employeeId = obj.employeeId;

                        var role = db.MstRoles.Where(b => b.id.Equals(objUser.roleId)).FirstOrDefault();
                        Session["RoleName"] = role.name.ToString();
                        var empl = db.MstEmployees.Where(c => c.id.Equals(objUser.employeeId)).FirstOrDefault();
                        Session["EmployeeName"] = empl.firstName.ToString();
                        return RedirectToAction("PilihOutlet");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult PilihOutlet()
        {
            if (Session["UserID"] != null)
            {
                ViewBag.ListProv = new SelectList(MstOutletRepo.GetData(), "id", "name");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PilihOutlet(MstOutletViewModel objUser)
        {
            if (ModelState.IsValid)
            {
                Session["OutletID"] = objUser.id;
                long sesID =objUser.id;
                using (POSContext db = new POSContext())
                {
                    var obj = db.MstOutlets.Where(a => a.id.Equals(sesID)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["OutletName"] = obj.name.ToString();
                        return RedirectToAction("Index","Employee");
                    }
                }
            }
            return RedirectToAction("Index","Employee");
        }

        public ActionResult GetOutletByUserID(int idx)
        {
            return Json(MstEmployeeOutletRepo.GetByProvId(idx), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session["UserID"] = null;
            Session["OutletID"] = null;
            Session["UserName"] = null;
            Session["RoleID"] = null;
            Session["RoleName"] = null;
            Session["EmployeeID"] = null;
            Session["EmployeeName"] = null;
            ViewBag.sesi = "Login";
            return RedirectToAction("Login");
        }

    }
}