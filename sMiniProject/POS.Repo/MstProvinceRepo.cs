using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class MstProvinceRepo
    {
        public static List<MstProvinceViewModel> GetData()
        {
            List<MstProvinceViewModel> result = new List<MstProvinceViewModel>();
            POSContext context = new POSContext();

            result = context.MstProvinces.Select(x => new MstProvinceViewModel()
            {
                id = x.id,
                name = x.name,

                createdBy = x.createdBy,
                createdOn = x.createdOn,
                modifiedBy = x.modifiedBy,
                modifiedOn = x.modifiedOn,

                active = x.active


            }).ToList();

            return result;
        }

        public static bool Add(MstProvinceViewModel model)
        {
            MstProvince province = new MstProvince();
            province.id = model.id;
            province.name = model.name;

            province.createdBy = model.createdBy;
            province.createdOn = DateTime.Now;
            //province.modifiedBy = model.createdBy;
            //province.modifiedOn = DateTime.Now;
            province.active = model.active;


            using (POSContext context = new POSContext())
            {
                context.MstProvinces.Add(province);
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

        public static bool Update(MstProvinceViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstProvince province = context.MstProvinces.Where(s => s.id == model.id).FirstOrDefault();
                province.id = model.id;
                province.name = model.name;

                province.modifiedBy = 1;
                province.modifiedOn = DateTime.Now;

                province.active = model.active;

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

        public static MstProvinceViewModel CariBerdasarkanId(int id)
        {
            MstProvinceViewModel ObjectHasilnya = new MstProvinceViewModel();
            using (POSContext _posContext = new POSContext())
            {
                ObjectHasilnya = (from mstA in _posContext.MstProvinces
                                  where mstA.id == id
                                  select new MstProvinceViewModel
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
            return ObjectHasilnya;
        }

        public static bool Delete(MstProvinceViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstProvince province = context.MstProvinces.Where(s => s.id == model.id).FirstOrDefault();
                context.MstProvinces.Remove(province);

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
