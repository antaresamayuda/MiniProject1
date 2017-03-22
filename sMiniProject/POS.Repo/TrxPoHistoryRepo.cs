using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class TrxPoHistoryRepo
    {
        public static List<TrxPoHistoryViewModel> GetData()
        {
            List<TrxPoHistoryViewModel> result = new List<TrxPoHistoryViewModel>();
            using (POSContext context = new POSContext())
            {
                result = context.TrxPoHistorys.Select(x => new TrxPoHistoryViewModel()
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

        public static bool Add(TrxPoHistoryViewModel IsiData)
        {
            TrxPoHistory poHistory = new TrxPoHistory();
            poHistory.id = IsiData.id;
            poHistory.headerId = IsiData.headerId;
            poHistory.statusId = IsiData.statusId;

            poHistory.createdOn = DateTime.Now;
            poHistory.createdBy = 1;

            using (POSContext context = new POSContext())
            {
                context.TrxPoHistorys.Add(poHistory);

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

        public static TrxPoHistoryViewModel CariID(int id)
        {
            TrxPoHistoryViewModel hasilID = new TrxPoHistoryViewModel();
            using (POSContext context = new POSContext())
            {
                hasilID = (from mstA in context.TrxPoHistorys
                           where mstA.id == id
                           select new TrxPoHistoryViewModel
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
        public static bool Update(TrxPoHistoryViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                TrxPoHistory poHistory = context.TrxPoHistorys.Where(s => s.id == IsiData.id).FirstOrDefault();

                poHistory.id = IsiData.id;
                poHistory.headerId = IsiData.headerId;
                poHistory.statusId = IsiData.statusId;

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


        public static bool Delete(TrxPoHistoryViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                TrxPoHistory poHistory = context.TrxPoHistorys.Where(s => s.id == IsiData.id).FirstOrDefault();
                context.TrxPoHistorys.Remove(poHistory);
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
