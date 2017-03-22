using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.ViewModel;
using POS.Model;

namespace POS.Repo
{
    public class MstDistrictRepo
    {
        public static List<MstDistrictViewModel> Getdata()
        {
            List<MstDistrictViewModel> result = new List<MstDistrictViewModel>();
            POSContext context = new POSContext();

            result = context.MstDistricts.Select(x => new MstDistrictViewModel()
            {
                id = x.id,
                regionId = x.regionId,
                name = x.name,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                ModifiedBy = x.ModifiedBy,
                ModifiedOn = x.ModifiedOn,
                active = x.active,
            }
            ).ToList();

            return result;
        }


        public static MstDistrictViewModel GetDataByID(int id)
        {
            MstDistrictViewModel result = new MstDistrictViewModel();
            using (POSContext context = new POSContext())
            {
                result = context.MstDistricts.Where(x => x.id == id)
                    .Select(x => new MstDistrictViewModel()
                    {
                        id = x.id,
                        regionId = x.regionId,
                        name = x.name,
                        CreatedBy = x.CreatedBy,
                        CreatedOn = x.CreatedOn,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedOn = x.ModifiedOn,
                        active = x.active,
                    }).FirstOrDefault();
            }
            return result;
        }

        public static MstDistrictViewModel CariID(int id)
        {
            MstDistrictViewModel hasilID = new MstDistrictViewModel();
            using (POSContext context = new POSContext())
            {
                hasilID = (from x in context.MstDistricts
                           where x.id == id
                           select new MstDistrictViewModel
                           {
                               id = x.id,
                               regionId = x.regionId,
                               name = x.name,
                               CreatedBy = x.CreatedBy,
                               CreatedOn = x.CreatedOn,
                               ModifiedBy = x.ModifiedBy,
                               ModifiedOn = x.ModifiedOn,
                               active = x.active
                           }
                           ).FirstOrDefault();
            }
            return hasilID;
        }

        public static bool Add(MstDistrictViewModel x)
        {
            MstDistrict District = new MstDistrict();
            District.id = x.id;
            District.regionId = x.regionId;
            District.name = x.name;
            District.CreatedBy = x.CreatedBy;
            District.CreatedOn = DateTime.Now;
            District.active = x.active;

            using (POSContext context = new POSContext())
            {
                context.MstDistricts.Add(District);
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


        public static bool Update(MstDistrictViewModel x)
        {
            using (POSContext context = new POSContext())
            {

                MstDistrict District = context.MstDistricts.Where(s => s.id == x.id).FirstOrDefault();

                District.id = x.id;
                District.regionId = x.regionId;
                District.name = x.name;
                District.ModifiedBy = x.ModifiedBy;
                District.ModifiedOn = DateTime.Now;
                District.active = x.active;

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


        public static bool Delete(MstDistrictViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                MstDistrict District = context.MstDistricts.Where(s => s.id == IsiData.id).FirstOrDefault();
                context.MstDistricts.Remove(District);
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


        public static List<MstDistrictViewModel> RegionDistrict(int id)
        {
            List<MstDistrictViewModel> result = new List<MstDistrictViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from Region in context.MstRegions
                          from District in context.MstDistricts
                          where Region.id == id && District.regionId == Region.id
                          select new MstDistrictViewModel
                          {
                              id = District.id,
                              name = District.name
                          }
                    ).ToList();
            }
            return result;
        }
    }
}
