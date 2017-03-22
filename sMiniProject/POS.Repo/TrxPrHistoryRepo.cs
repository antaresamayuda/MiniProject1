using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;


namespace POS.Repo
{
    public class TrxPrHistoryRepo
    {
        public static List<TrxPrHistoryViewModel> GetData()
        {
            List<TrxPrHistoryViewModel> result = new List<TrxPrHistoryViewModel>();
            using (POSContext context = new POSContext())
            {
                result = context.TrxPrHistorys.Select(x => new TrxPrHistoryViewModel()
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

        public static bool Add(TrxPrHistoryViewModel IsiData)
        {
            TrxPrHistory prHistory = new TrxPrHistory();
            prHistory.id = IsiData.id;
            prHistory.headerId = IsiData.headerId;
            prHistory.statusId = IsiData.statusId;

            prHistory.createdOn = DateTime.Now;
            prHistory.createdBy = 1;

            using (POSContext context = new POSContext())
            {
                context.TrxPrHistorys.Add(prHistory);

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

        public static TrxPrHistoryViewModel CariID(int id)
        {
            TrxPrHistoryViewModel hasilID = new TrxPrHistoryViewModel();
            using (POSContext context = new POSContext())
            {
                hasilID = (from mstA in context.TrxPrHistorys
                           where mstA.id == id
                           select new TrxPrHistoryViewModel
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
        public static bool Update(TrxPrHistoryViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                TrxPrHistory prHistory = context.TrxPrHistorys.Where(s => s.id == IsiData.id).FirstOrDefault();

                prHistory.id = IsiData.id;
                prHistory.headerId = IsiData.headerId;
                prHistory.statusId = IsiData.statusId;

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


        public static bool Delete(TrxPrHistoryViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                TrxPrHistory prHistory = context.TrxPrHistorys.Where(s => s.id == IsiData.id).FirstOrDefault();
                context.TrxPrHistorys.Remove(prHistory);
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
