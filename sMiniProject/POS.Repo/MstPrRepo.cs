using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class MstPrRepo
    {

        public static List<MstPrViewModel> GetData()
        {
            List<MstPrViewModel> result = new List<MstPrViewModel>();
            POSContext context = new POSContext();

            result = context.MstPrs.Select(x => new MstPrViewModel()
            {
                id = x.id,
                outletId =x.outletId,
                readyTime = x.readyTime,
                prNo = x.prNo,
                notes = x.notes,
                statusId = x.statusId,

                createdBy = x.createdBy,
                createdOn = x.createdOn,
                modifiedBy = x.modifiedBy,
                modifiedOn = x.modifiedOn,


            }).ToList();

            return result;
        }

        public static bool Add(MstPrViewModel model)
        {
            MstPr pr = new MstPr();
            pr.id = model.id;
            pr.outletId = model.outletId;
            pr.readyTime = model.readyTime;
            pr.prNo = model.prNo;
            pr.notes = model.notes;
            pr.statusId = model.statusId;

            pr.createdBy = model.createdBy;
            pr.createdOn = DateTime.Now;
            //pr.modifiedBy = model.createdBy;
            //pr.modifiedOn = DateTime.Now;


            using (POSContext context = new POSContext())
            {
                context.MstPrs.Add(pr);
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

        public static bool Update(MstPrViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstPr pr = context.MstPrs.Where(s => s.id == model.id).FirstOrDefault();
                pr.id = model.id;
                pr.outletId = model.outletId;
                pr.readyTime = model.readyTime;
                pr.prNo = model.prNo;
                pr.notes = model.notes;
                pr.statusId = model.statusId;

                pr.modifiedBy = 1;
                pr.modifiedOn = DateTime.Now;

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

        public static MstPrViewModel CariBerdasarkanId(int id)
        {
            MstPrViewModel ObjectHasilnya = new MstPrViewModel();
            using (POSContext _posContext = new POSContext())
            {
                ObjectHasilnya = (from mstA in _posContext.MstPrs
                                  where mstA.id == id
                                  select new MstPrViewModel
                                  {
                                      id = mstA.id,
                                      outletId = mstA.outletId,
                                      readyTime = mstA.readyTime,
                                      prNo = mstA.prNo,
                                      notes = mstA.notes,
                                      statusId =mstA.statusId,

                                      createdBy = mstA.createdBy,
                                      createdOn = mstA.createdOn,
                                      modifiedBy = mstA.modifiedBy,
                                      modifiedOn = mstA.modifiedOn,
                                  }
                                 ).FirstOrDefault();

            }
            return ObjectHasilnya;
        }

        public static bool Delete(MstPrViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstPr pr = context.MstPrs.Where(s => s.id == model.id).FirstOrDefault();
                context.MstPrs.Remove(pr);

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
