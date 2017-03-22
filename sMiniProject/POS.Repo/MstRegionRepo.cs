using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class MstRegionRepo
    {
        public static List<MstRegionViewModel> GetData()
        {
            List<MstRegionViewModel> result = new List<MstRegionViewModel>();
            POSContext context = new POSContext();

            result = context.MstRegions.Select(x => new MstRegionViewModel()
            {
                id = x.id,
                provinceId = x.provinceId,
                name = x.name,

                createdBy = x.createdBy,
                createdOn = x.createdOn,
                modifiedBy = x.modifiedBy,
                modifiedOn = x.modifiedOn,

                active = x.active
                

            }).ToList();

            return result;
        }

        public static bool Add(MstRegionViewModel model)
        {
            MstRegion region = new MstRegion();
            region.id = model.id;
            region.provinceId = model.provinceId;
            region.name = model.name;

            region.createdBy = model.createdBy;
            region.createdOn = DateTime.Now;
            //region.modifiedBy = model.createdBy;
            //region.modifiedOn = DateTime.Now;
            region.active = model.active;
            

            using (POSContext context = new POSContext())
            {
                context.MstRegions.Add(region);
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

        public static bool Update(MstRegionViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstRegion region = context.MstRegions.Where(s => s.id == model.id).FirstOrDefault();
                region.id = model.id;
                region.provinceId = model.provinceId;
                region.name = model.name;

                region.modifiedBy = 1;
                region.modifiedOn = DateTime.Now;

                region.active = model.active;

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

        public static MstRegionViewModel CariBerdasarkanId(int id)
        {
            MstRegionViewModel ObjectHasilnya = new MstRegionViewModel();
            using (POSContext _posContext = new POSContext())
            {
                ObjectHasilnya = (from mstA in _posContext.MstRegions
                                  where mstA.id == id
                                  select new MstRegionViewModel
                                  {
                                      id = mstA.id,
                                      provinceId = mstA.provinceId,
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

        public static bool Delete(MstRegionViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstRegion region = context.MstRegions.Where(s => s.id == model.id).FirstOrDefault();
                context.MstRegions.Remove(region);

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


        public static List<MstRegionViewModel> ProvRegion(int id)
        {
            List<MstRegionViewModel> result = new List<MstRegionViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from Region in context.MstRegions
                          from Prov in context.MstProvinces
                          where Prov.id == id && Prov.id==Region.provinceId
                          select new MstRegionViewModel
                          {
                              id = Region.id,
                              name = Region.name
                          }
                    ).ToList();
            }
            return result;
        }



    }
}
