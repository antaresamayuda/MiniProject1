using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class TrxAdjustmentHistoryRepo
    {
        public static List<TrxAdjustmentHistoryViewModel> GetData(int id)
        {
            List<TrxAdjustmentHistoryViewModel> result = new List<TrxAdjustmentHistoryViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (
                                from history in context.TrxAdjustmentHistorys
                                from status in context.MstStatuss

                                where history.headerId == id && history.statusId == status.id
                                select new TrxAdjustmentHistoryViewModel
                                {
                                    id=history.id,
                                    headerId =history.headerId,
                                    statusId=history.statusId,
                                    CreatedBy=history.createdBy,
                                    CreatedOn=history.createdOn,

                                    statusName = status.name

                                }).ToList();
            }
            return result;
        }

        public static bool Add(TrxAdjustmentHistoryViewModel IsiData)
        {
            TrxAdjustmentHistory aHistory = new TrxAdjustmentHistory();
            aHistory.id = IsiData.id;
            aHistory.headerId = IsiData.headerId;
            aHistory.statusId = IsiData.statusId;

            aHistory.createdOn = DateTime.Now;
            aHistory.createdBy = 1;

            using (POSContext context = new POSContext())
            {
                context.TrxAdjustmentHistorys.Add(aHistory);

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

        public static TrxAdjustmentHistoryViewModel CariID(int id)
        {
            TrxAdjustmentHistoryViewModel hasilID = new TrxAdjustmentHistoryViewModel();
            using (POSContext context = new POSContext())
            {
                hasilID = (from mstA in context.TrxAdjustmentHistorys
                           where mstA.id == id
                           select new TrxAdjustmentHistoryViewModel
                           {
                               id = mstA.id,
                               headerId = mstA.headerId,
                               statusId = mstA.statusId,
                               CreatedBy = mstA.createdBy,
                               CreatedOn = mstA.createdOn,

                           }
                           ).FirstOrDefault();
            }
            return hasilID;
        }
        public static bool Update(TrxAdjustmentHistoryViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                TrxAdjustmentHistory aHistory = context.TrxAdjustmentHistorys.Where(s => s.id == IsiData.id).FirstOrDefault();

                aHistory.id = IsiData.id;
                aHistory.headerId = IsiData.headerId;
                aHistory.statusId = IsiData.statusId;

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


        public static bool Delete(TrxAdjustmentHistoryViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                TrxAdjustmentHistory aHistory = context.TrxAdjustmentHistorys.Where(s => s.id == IsiData.id).FirstOrDefault();
                context.TrxAdjustmentHistorys.Remove(aHistory);
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
