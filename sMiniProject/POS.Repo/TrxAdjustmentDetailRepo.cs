using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.ViewModel;
using POS.Model;

namespace POS.Repo
{
    public class TrxAdjustmentDetailRepo
    {
        public static List<TrxAdjustmentDetailViewModel> Getdata(int id)
        {
            List<TrxAdjustmentDetailViewModel> result = new List<TrxAdjustmentDetailViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (
                                from Adjustment in context.TrxAdjustments
                                from AD in context.TrxAdjustmentDetails
                                from Variant in context.MstItemVariants

                                where AD.headerId == Adjustment.id && AD.variantId == Variant.id 
                                       && AD.headerId == id
                                select new TrxAdjustmentDetailViewModel
                                {
                                    id = AD.id,
                                    headerId = Adjustment.id,
                                    StatID = Adjustment.statusId,

                                    variantId = AD.variantId,
                                    varName = Variant.name,
                                    inStock = AD.inStock,
                                    actualStock = AD.actualStock,


                                    CreatedBy = Adjustment.CreatedBy,
                                    CreatedOn = Adjustment.CreatedOn,
                                    ModifiedBy = Adjustment.ModifiedBy,
                                    ModifiedOn = Adjustment.ModifiedOn,


                                }).ToList();
            }
            return result;
        }
        

        public static TrxAdjustmentDetailViewModel GetDataByID(int id)
        {
            TrxAdjustmentDetailViewModel result = new TrxAdjustmentDetailViewModel();
            using (POSContext context = new POSContext())
            {
                result = context.TrxAdjustmentDetails.Where(x => x.id == id)
                    .Select(x => new TrxAdjustmentDetailViewModel()
                    {
                        id = x.id,
                        headerId = x.headerId,
                        variantId = x.variantId,
                        inStock = x.inStock,
                        actualStock = x.actualStock,
                        CreatedBy = x.CreatedBy,
                        CreatedOn = x.CreatedOn,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedOn = x.ModifiedOn,
                    }).FirstOrDefault();
            }
            return result;
        }

        public static TrxAdjustmentDetailViewModel CariID(int id)
        {
            TrxAdjustmentDetailViewModel hasilID = new TrxAdjustmentDetailViewModel();
            using (POSContext context = new POSContext())
            {
                hasilID = (from x in context.TrxAdjustmentDetails
                           where x.id == id
                           select new TrxAdjustmentDetailViewModel
                           {
                               id = x.id,
                               headerId = x.headerId,
                               variantId = x.variantId,
                               inStock = x.inStock,
                               actualStock = x.actualStock,

                               CreatedBy = x.CreatedBy,
                               CreatedOn = x.CreatedOn,
                               ModifiedBy = x.ModifiedBy,
                               ModifiedOn = x.ModifiedOn,
                           }
                           ).FirstOrDefault();
            }
            return hasilID;
        }

        public static bool Add(TrxAdjustmentDetailViewModel x)
        {
            TrxAdjustmentDetail Adj = new TrxAdjustmentDetail();
            Adj.id = x.id;
            Adj.headerId = x.headerId;
            Adj.variantId = x.variantId;
            Adj.inStock = x.inStock;
            Adj.actualStock = x.actualStock;
            Adj.CreatedBy = x.CreatedBy;
            Adj.CreatedOn = DateTime.Now;

            using (POSContext context = new POSContext())
            {
                context.TrxAdjustmentDetails.Add(Adj);
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


        public static bool Update(TrxAdjustmentDetailViewModel x)
        {
            using (POSContext context = new POSContext())
            {

                TrxAdjustmentDetail Adj = context.TrxAdjustmentDetails.Where(s => s.id == x.id).FirstOrDefault();

                Adj.id = x.id;
                Adj.headerId = x.headerId;
                Adj.variantId = x.variantId;
                Adj.inStock = x.inStock;
                Adj.actualStock = x.actualStock;
                Adj.ModifiedBy = x.ModifiedBy;
                Adj.ModifiedOn = DateTime.Now;

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


        public static bool Delete(TrxAdjustmentDetailViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                TrxAdjustmentDetail Adj = context.TrxAdjustmentDetails.Where(s => s.id == IsiData.id).FirstOrDefault();
                context.TrxAdjustmentDetails.Remove(Adj);
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
