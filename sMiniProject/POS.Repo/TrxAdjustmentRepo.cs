using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.ViewModel;
using POS.Model;

namespace POS.Repo
{
    public class TrxAdjustmentRepo
    {
        public static List<TrxAdjustmentViewModel> Getdata(string sesi)
        {
            long sesiOutlet = long.Parse(sesi);
            List<TrxAdjustmentViewModel> result = new List<TrxAdjustmentViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (
                                from Adjustment in context.TrxAdjustments
                                from State in context.MstStatuss

                                where Adjustment.statusId == State.id && Adjustment.outletId==sesiOutlet
                                select new TrxAdjustmentViewModel
                                {
                                    id = Adjustment.id,
                                    outletId = Adjustment.outletId,
                                    notes = Adjustment.notes,
                                    statusId = Adjustment.statusId,

                                    CreatedBy = Adjustment.CreatedBy,
                                    CreatedOn = Adjustment.CreatedOn,
                                    ModifiedBy = Adjustment.ModifiedBy,
                                    ModifiedOn = Adjustment.ModifiedOn,
                                    
                                    StatusName = State.name

                                }).ToList();
            }
            return result;
        }


        public static TrxAdjustmentViewModel GetDataByID(int id)
        {
            TrxAdjustmentViewModel result = new TrxAdjustmentViewModel();
            using (POSContext context = new POSContext())
            {
                result = context.TrxAdjustments.Where(x => x.id == id)
                    .Select(x => new TrxAdjustmentViewModel()
                    {
                        id = x.id,
                        outletId = x.outletId,
                        notes = x.notes,
                        statusId = x.statusId,
                        CreatedBy = x.CreatedBy,
                        CreatedOn = x.CreatedOn,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedOn = x.ModifiedOn,
                    }).FirstOrDefault();
            }
            return result;
        }


        public static bool InsertData(Model.POSContext context, TrxAdjustmentViewModel model)
        {
            bool result = false;
            int headerID = 1;
            POSContext conn = new POSContext();
            
            var nmax = (from adjustment in context.TrxAdjustments
                        select new TrxAdjustmentViewModel()
                            ).Count();

            if (nmax < 1)
            {
                headerID = 1;
            }
            else
            {
                headerID = 1 + nmax;

            }

                context.TrxAdjustments.Add(new Model.TrxAdjustment()

                {
                    id = headerID,
                    outletId = model.outletId,
                    notes = model.notes,
                    statusId = 1,
                    CreatedOn = DateTime.Now,
                    CreatedBy = 1

                }
                );

            //--------------------------------------------------------------------
                if (model.inventory != null)
                {                                    
                    foreach (var item in model.inventory)
                    {                                  
                        context.TrxAdjustmentDetails.Add(new Model.TrxAdjustmentDetail()
                        {
                            headerId = headerID,
                            variantId = item.variantId,
                            inStock = item.InStock,
                            actualStock = item.AdjustQty,
                            CreatedOn = DateTime.Now,
                            CreatedBy = 1
                        }
                            );
                       

                    }

                }

            //--------------------------------------------------------------------


                context.TrxAdjustmentHistorys.Add(new Model.TrxAdjustmentHistory()
                    {
                        headerId = headerID,
                        statusId = 1,
                        createdOn = DateTime.Now,
                        createdBy = 1,
                    });

                     


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




        public static TrxAdjustmentViewModel CariID(int id)
        {
            TrxAdjustmentViewModel hasilID = new TrxAdjustmentViewModel();
            using (POSContext context = new POSContext())
            {
                hasilID = (
                           from Adjustment in context.TrxAdjustments
                           from AD in context.TrxAdjustmentDetails
                           from Variant in context.MstItemVariants
                           from State in context.MstStatuss

                           where Adjustment.id == id &&
                                 Adjustment.id == AD.headerId && AD.variantId == Variant.id && Adjustment.statusId == State.id

                           select new TrxAdjustmentViewModel
                           {
                               id = Adjustment.id,
                               outletId = Adjustment.outletId,
                               notes = Adjustment.notes,
                               statusId = Adjustment.statusId,

                               A = AD.variantId,
                               AName = Variant.name,
                               B = AD.inStock,
                               C = AD.actualStock,

                               CreatedBy = Adjustment.CreatedBy,
                               CreatedOn = Adjustment.CreatedOn,
                               ModifiedBy = Adjustment.ModifiedBy,
                               ModifiedOn = Adjustment.ModifiedOn,

                               StatusName = State.name

                           }
                           ).FirstOrDefault();
            }
            return hasilID;
        }


        //public static bool Update(TrxAdjustmentViewModel x)
        //{
        //    using (POSContext context = new POSContext())
        //    {
        //        TrxAdjustment Adj = context.TrxAdjustments.Where(s => s.id == x.id).FirstOrDefault();

        //        //Adj.id = x.id;
        //        //Adj.outletId = x.outletId;
        //        //Adj.notes = x.notes;
        //        Adj.statusId = x.statusId;

        //        //Adj.CreatedBy = x.CreatedBy;
        //        //Adj.CreatedOn = x.CreatedOn;
        //        Adj.ModifiedBy = 1;
        //        Adj.ModifiedOn = DateTime.Now;

        //        try
        //        {
        //            context.SaveChanges();
        //            return true;
        //        }
        //        catch (Exception)
        //        {

        //            return false;
        //        }
        //    }
        //}


        public static bool Delete(TrxAdjustmentViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                TrxAdjustment Adj = context.TrxAdjustments.Where(s => s.id == IsiData.id).FirstOrDefault();
                context.TrxAdjustments.Remove(Adj);
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
