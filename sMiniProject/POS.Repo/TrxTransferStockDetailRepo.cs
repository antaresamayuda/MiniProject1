using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class TrxTransferStockDetailRepo
    {
        public static List<TrxTransferStockDetailViewModel> GetData()
        {
            List<TrxTransferStockDetailViewModel> result = new List<TrxTransferStockDetailViewModel>();
            using (POSContext context = new POSContext())
            {
                result = context.TrxTransferStockDetails.Select(x => new TrxTransferStockDetailViewModel()
                {
                    id = x.id,
                    headerId = x.headerId,
                    instock = x.instock,
                    variantId = x.variantId,
                    transferQty = x.transferQty,
                    createdBy = x.createdBy,
                    createdOn = x.createdOn,
                    modifiedBy = x.modifiedBy,
                    modifiedOn = x.modifiedOn

                }).ToList();
            }
            return result;
        }

        public static bool Add(TrxTransferStockDetailViewModel IsiData)
        {
            TrxTransferStockDetail Transfer = new TrxTransferStockDetail();
            Transfer.id = IsiData.id;
            Transfer.headerId = IsiData.headerId;
            Transfer.instock = IsiData.instock;
            Transfer.variantId = IsiData.variantId;
            Transfer.transferQty = IsiData.transferQty;

            Transfer.createdOn = DateTime.Now;
            Transfer.createdBy = 1;

            using (POSContext context = new POSContext())
            {
                context.TrxTransferStockDetails.Add(Transfer);

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static TrxTransferStockDetailViewModel CariID(int id)
        {
            TrxTransferStockDetailViewModel hasilID = new TrxTransferStockDetailViewModel();
            using (POSContext context = new POSContext())
            {
                hasilID = (from mstA in context.TrxTransferStockDetails
                           where mstA.id == id
                           select new TrxTransferStockDetailViewModel
                           {
                               id = mstA.id,
                               headerId = mstA.headerId,
                               instock = mstA.instock,
                               variantId = mstA.variantId,
                               transferQty = mstA.transferQty,
                               createdBy = mstA.createdBy,
                               createdOn = mstA.createdOn,
                               modifiedBy = mstA.modifiedBy,
                               modifiedOn = mstA.modifiedOn
                           }
                           ).FirstOrDefault();
            }
            return hasilID;
        }
        public static bool Update(TrxTransferStockDetailViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                TrxTransferStockDetail Transfer = context.TrxTransferStockDetails.Where(s => s.id == IsiData.id).FirstOrDefault();

                Transfer.id = IsiData.id;
                Transfer.headerId = IsiData.headerId;
                Transfer.instock = IsiData.instock;
                Transfer.variantId = IsiData.variantId;
                Transfer.transferQty = IsiData.transferQty;

                Transfer.modifiedOn = DateTime.Now;
                Transfer.modifiedBy = 1;
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


        public static bool Delete(TrxTransferStockDetailViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                TrxTransferStockDetail Transfer = context.TrxTransferStockDetails.Where(s => s.id == IsiData.id).FirstOrDefault();
                context.TrxTransferStockDetails.Remove(Transfer);
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
