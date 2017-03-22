using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class MstStatusRepo
    {
        public static List<MstStatusViewModel> GetData()
        {
            List<MstStatusViewModel> result = new List<MstStatusViewModel>();
            using (POSContext context = new POSContext())
            {
                result = context.MstStatuss.Select(x => new MstStatusViewModel()
                {
                    id = x.id,
                    name = x.name,                    
                    createdBy = x.createdBy,
                    createdOn = x.createdOn,
                    modifiedBy = x.modifiedBy,
                    modifiedOn = x.modifiedOn,
                    active= x.active

                }).ToList();
            }
            return result;
        }

        public static bool Add(MstStatusViewModel IsiData)
        {
            MstStatus Status = new MstStatus();
            Status.id = IsiData.id;
            Status.name = IsiData.name;                      
            
            Status.createdOn = DateTime.Now;
            Status.createdBy = 1;
            Status.active = IsiData.active;

            using (POSContext context = new POSContext())
            {
                context.MstStatuss.Add(Status);

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

        public static MstStatusViewModel CariID(int id)
        {
            MstStatusViewModel hasilID = new MstStatusViewModel();
            using (POSContext context = new POSContext())
            {
                hasilID = (from mstA in context.MstStatuss
                           where mstA.id == id
                           select new MstStatusViewModel
                           {
                               id = mstA.id,
                               name = mstA.name,                              
                               createdBy = mstA.createdBy,
                               createdOn = mstA.createdOn,
                               modifiedBy = mstA.modifiedBy,
                               modifiedOn = mstA.modifiedOn,
                               active = mstA.active
                           }
                           ).FirstOrDefault();
            }
            return hasilID;
        }
        public static bool Update(MstStatusViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                MstStatus Status = context.MstStatuss.Where(s => s.id == IsiData.id).FirstOrDefault();

                Status.id = IsiData.id;
                Status.name = IsiData.name;               

                Status.modifiedOn = DateTime.Now;
                Status.modifiedBy = 1;
                //Status.active = IsiData.active;

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


        public static bool Delete(MstStatusViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                MstStatus Status = context.MstStatuss.Where(s => s.id == IsiData.id).FirstOrDefault();
                context.MstStatuss.Remove(Status);
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
