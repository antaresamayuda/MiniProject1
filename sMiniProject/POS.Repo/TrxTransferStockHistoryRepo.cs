using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class TrxTransferStockHistoryRepo
    {
        public static List<TrxTransferStockHistoryViewModel> GetData()
        {
            List<TrxTransferStockHistoryViewModel> result = new List<TrxTransferStockHistoryViewModel>();
            using (POSContext context = new POSContext())
            {
                result = context.TrxTransferStockHistorys.Select(x => new TrxTransferStockHistoryViewModel()
                {
                    id = x.id,
                    headerId = x.headerId,
                    statusId = x.statusId,
                    createdBy = x.createdBy,
                    createdOn = x.createdOn,

                }).ToList();
            }
            return result;
        }

        public static bool Add(TrxTransferStockHistoryViewModel IsiData)
        {
            TrxTransferStockHistory tsHistory = new TrxTransferStockHistory();
            tsHistory.id = IsiData.id;
            tsHistory.headerId = IsiData.headerId;
            tsHistory.statusId = IsiData.statusId;

            tsHistory.createdOn = DateTime.Now;
            tsHistory.createdBy = 1;

            using (POSContext context = new POSContext())
            {
                context.TrxTransferStockHistorys.Add(tsHistory);

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

        public static TrxTransferStockHistoryViewModel CariID(int id)
        {
            TrxTransferStockHistoryViewModel hasilID = new TrxTransferStockHistoryViewModel();
            using (POSContext context = new POSContext())
            {
                hasilID = (from mstA in context.TrxTransferStockHistorys
                           where mstA.id == id
                           select new TrxTransferStockHistoryViewModel
                           {
                               id = mstA.id,
                               headerId = mstA.headerId,
                               statusId = mstA.statusId,
                               createdBy = mstA.createdBy,
                               createdOn = mstA.createdOn,

                           }
                           ).FirstOrDefault();
            }
            return hasilID;
        }
        public static bool Update(TrxTransferStockHistoryViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                TrxTransferStockHistory tsHistory = context.TrxTransferStockHistorys.Where(s => s.id == IsiData.id).FirstOrDefault();

                tsHistory.id = IsiData.id;
                tsHistory.headerId = IsiData.headerId;
                tsHistory.statusId = IsiData.statusId;

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


        public static bool Delete(TrxTransferStockHistoryViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                TrxTransferStockHistory tsHistory = context.TrxTransferStockHistorys.Where(s => s.id == IsiData.id).FirstOrDefault();
                context.TrxTransferStockHistorys.Remove(tsHistory);
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
