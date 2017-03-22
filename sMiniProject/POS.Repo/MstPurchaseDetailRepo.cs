using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class MstPurchaseDetailRepo
    {
        public static List<MstPurchaseDetailViewModel> GetData()
        {
            List<MstPurchaseDetailViewModel> result = new List<MstPurchaseDetailViewModel>();
            POSContext context = new POSContext();

            result = context.MstPurchaseDetails.Select(x => new MstPurchaseDetailViewModel()
            {
                id = x.id,
                headerId = x.headerId,
                variantId = x.variantId,
                requestQty = x.requestQty,
                unitCost = x.unitCost,
                subTotal = x.subTotal,

                createdBy = x.createdBy,
                createdOn = x.createdOn,
                modifiedBy = x.modifiedBy,
                modifiedOn = x.modifiedOn,


            }).ToList();

            return result;
        }

        public static bool Add(MstPurchaseDetailViewModel model)
        {
            MstPurchaseDetail purchaseDetail = new MstPurchaseDetail();
            purchaseDetail.id = model.id;
            purchaseDetail.headerId = model.headerId;
            purchaseDetail.variantId = model.variantId;
            purchaseDetail.requestQty = model.requestQty;
            purchaseDetail.unitCost = model.unitCost;
            purchaseDetail.subTotal = model.subTotal;

            purchaseDetail.createdBy = model.createdBy;
            purchaseDetail.createdOn = DateTime.Now;
            //purchaseDetail.modifiedBy = model.createdBy;
            //purchaseDetail.modifiedOn = DateTime.Now;


            using (POSContext context = new POSContext())
            {
                context.MstPurchaseDetails.Add(purchaseDetail);
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }

        }

        public static bool Update(MstPurchaseDetailViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstPurchaseDetail purchaseDetail = context.MstPurchaseDetails.Where(s => s.id == model.id).FirstOrDefault();
                purchaseDetail.id = model.id;
                purchaseDetail.headerId = model.headerId;
                purchaseDetail.variantId = model.variantId;
                purchaseDetail.requestQty = model.requestQty;
                purchaseDetail.unitCost = model.unitCost;
                purchaseDetail.subTotal = model.subTotal;

                purchaseDetail.modifiedBy = model.modifiedBy;
                purchaseDetail.modifiedOn = DateTime.Now;

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }


        }

        public static MstPurchaseDetailViewModel CariBerdasarkanId(int id)
        {
            MstPurchaseDetailViewModel ObjectHasilnya = new MstPurchaseDetailViewModel();
            using (POSContext _posContext = new POSContext())
            {
                ObjectHasilnya = (from mstA in _posContext.MstPurchaseDetails
                                  where mstA.id == id
                                  select new MstPurchaseDetailViewModel
                                  {
                                      id = mstA.id,
                                      headerId = mstA.headerId,
                                      variantId = mstA.variantId,
                                      requestQty = mstA.requestQty,
                                      unitCost = mstA.unitCost,
                                      subTotal = mstA.subTotal,

                                      createdBy = mstA.createdBy,
                                      createdOn = mstA.createdOn,
                                      modifiedBy = mstA.modifiedBy,
                                      modifiedOn = mstA.modifiedOn,
                                  }
                                 ).FirstOrDefault();

            }
            return ObjectHasilnya;
        }

        public static bool Delete(MstPurchaseDetailViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstPurchaseDetail purchaseDetail = context.MstPurchaseDetails.Where(s => s.id == model.id).FirstOrDefault();
                context.MstPurchaseDetails.Remove(purchaseDetail);

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }



    }
}
