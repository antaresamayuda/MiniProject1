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
    public class AdjustmentController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            string sesi;
            if (Session["OutletID"] == null) { sesi = "1"; }
            else
            {
                sesi = Session["OutletID"].ToString();
            }
            return View(TrxAdjustmentRepo.Getdata(sesi));
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(TrxAdjustmentViewModel IsiData)
        {
            if (ModelState.IsValid)
            {
                POS.Model.POSContext context = new Model.POSContext();
                if (TrxAdjustmentRepo.InsertData(context, IsiData))
                {
                    return RedirectToAction("index");
                }
            }

            return PartialView("Create", IsiData);
        }

        public ActionResult Approve(int id)
        {
            //TrxAdjustmentViewModel model = TrxAdjustmentRepo.CariID(id);

            using (POSContext context = new POSContext())
            {

                TrxAdjustment Adj = context.TrxAdjustments.Where(s => s.id == id).FirstOrDefault();
                //TrxAdjustmentHistory adjHist = context.TrxAdjustmentHistorys.Where(s => s.headerId == id).FirstOrDefault();
                //adjHist.statusId = 2;
                TrxAdjustmentHistory history = context.TrxAdjustmentHistorys.Where(s => s.headerId == id).FirstOrDefault();
                context.TrxAdjustmentHistorys.Add(new Model.TrxAdjustmentHistory()
                {
                    headerId = id,
                    statusId = 2,
                    createdOn = DateTime.Now,
                    createdBy = 1,
                });

                Adj.statusId = 2;
                Adj.ModifiedBy = 1;
                Adj.ModifiedOn = DateTime.Now;

                //script edit stok item inventory
                using (POSContext update = new POSContext())
                {
                var Object = (from Adjust in context.TrxAdjustments
                                  from AD in context.TrxAdjustmentDetails
                                  where Adjust.id == id && Adjust.id == AD.headerId 
                                  select new TrxAdjustmentDetailViewModel
                                  {
                                      variantId = AD.variantId,
                                      actualStock = AD.actualStock
                                  }
                                  ).ToList();

                List<TrxAdjustmentDetailViewModel> list = new List<TrxAdjustmentDetailViewModel>(Object);

                foreach (var item in list)
                {                                   
                        //TrxAdjustmentDetail AD = context.TrxAdjustmentDetails.Where(s => s.headerId == id).FirstOrDefault();

                        MstItemInventory updateStok = context.MstItemInventorys.Where(s => s.variantId == item.variantId).FirstOrDefault();
                        updateStok.adjustmentQty = item.actualStock;
                        updateStok.endingQty = item.actualStock;

                        update.SaveChanges();
                    };
                }

                try
                {
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Reject(int id)
        {

            using (POSContext context = new POSContext())
            {

                TrxAdjustment Adj = context.TrxAdjustments.Where(s => s.id == id).FirstOrDefault();
                //TrxAdjustmentHistory adjHist = context.TrxAdjustmentHistorys.Where(s => s.headerId == id).FirstOrDefault();
                //adjHist.statusId = 3;

                TrxAdjustmentHistory history = context.TrxAdjustmentHistorys.Where(s => s.headerId == id).FirstOrDefault();
                context.TrxAdjustmentHistorys.Add(new Model.TrxAdjustmentHistory()
                {
                    headerId = id,
                    statusId = 3,
                    createdOn = DateTime.Now,
                    createdBy = 1,
                });

                Adj.statusId = 3;
                Adj.ModifiedBy = 1;
                Adj.ModifiedOn = DateTime.Now;

                try
                {
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    return RedirectToAction("Index");
                }
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(TrxAdjustmentViewModel data)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (TrxAdjustmentRepo.Update(data))
        //        {
        //            return RedirectToAction("Index");
        //        }

        //    }
        //    return PartialView("Edit", data);
        //}

        public ActionResult Details(int id)
        {
            TrxAdjustmentViewModel model = TrxAdjustmentRepo.CariID(id);
            return PartialView("Details", model);
        }


        public ActionResult Delete(int id)
        {
            TrxAdjustmentViewModel model = TrxAdjustmentRepo.CariID(id);
            return PartialView("Delete", model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAnggota(TrxAdjustmentViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (TrxAdjustmentRepo.Delete(data))
                {
                    return RedirectToAction("index");
                }
            }
            return View("index");
        }
    }
}