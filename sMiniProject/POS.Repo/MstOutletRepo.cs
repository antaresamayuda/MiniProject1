using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class MstOutletRepo
    {
        public static ViewModel.MstOutletViewModel GetDataById(int id)
        {
            ViewModel.MstOutletViewModel result = new ViewModel.MstOutletViewModel();
            using (Model.POSContext context = new Model.POSContext())
            {
                result = context.MstOutlets.Where(x => x.id == id)
                    .Select(x => new ViewModel.MstOutletViewModel()
                    {
                        id = x.id,
                        name = x.name,
                        address = x.address,
                        phone = x.phone,
                        email = x.email,
                        provinceId = x.provinceId,
                        regionId = x.regionId,
                        districtId = x.districtId,
                        postalCode = x.postalCode,
                        createdBy = x.createdBy,
                        createdOn = x.createdOn,
                        modifiedBy = x.modifiedBy,
                        modifiedOn = x.modifiedOn,
                        active = x.active
                    }).FirstOrDefault();
            }
            return result;
        }

        public static List<MstOutletViewModel> GetData()
        {
            List<MstOutletViewModel> result = new List<MstOutletViewModel>();
            using (POSContext context = new POSContext())
            {
                result = context.MstOutlets.Select(x => new MstOutletViewModel()
                {
                    id = x.id,
                    name = x.name,
                    address = x.address,
                    phone = x.phone,
                    email = x.email,
                    provinceId = x.provinceId,
                    regionId = x.regionId,
                    districtId = x.districtId,
                    postalCode = x.postalCode,
                    createdBy = x.createdBy,
                    createdOn = x.createdOn,
                    modifiedBy = x.modifiedBy,
                    modifiedOn = x.modifiedOn,
                    active= x.active

                }).Take(10).ToList();
            }
            return result;
        }

        public static List<MstOutletViewModel> GetAllSearch(string strSearch)
        {
            List<MstOutletViewModel> result = new List<MstOutletViewModel>();
            using (var context = new POSContext())
            {
                result = (
                          from EM in context.MstOutlets
                          where EM.name.Contains(strSearch)
                          select new MstOutletViewModel
                          {
                              id = EM.id,
                              name = EM.name
                          }
                    ).ToList();
            }
            return result;
        }

        public static List<MstOutletViewModel> GetSearchIndex(string strSearch)
        {
            List<MstOutletViewModel> result = new List<MstOutletViewModel>();
            using (var context = new POSContext())
            {
                result = (from mstS in context.MstOutlets
                          from mstP in context.MstProvinces
                          from mstR in context.MstRegions
                          from mstD in context.MstDistricts
                          where mstS.provinceId == mstP.id && mstS.regionId == mstR.id && mstS.districtId == mstD.id && mstS.name.Contains(strSearch)
                          select new MstOutletViewModel
                          {
                              id = mstS.id,
                              name = mstS.name,
                              address = mstS.address,
                              phone = mstS.phone,
                              email = mstS.email,
                              provinceId = mstS.provinceId,
                              regionId = mstS.regionId,
                              districtId = mstS.districtId,
                              postalCode = mstS.postalCode,
                              createdBy = mstS.createdBy,
                              createdOn = mstS.createdOn,
                              modifiedBy = mstS.modifiedBy,
                              modifiedOn = mstS.modifiedOn,
                              active = mstS.active,
                              nameProvinsi = mstP.name,
                              nameRegion = mstR.name,
                              nameDistrict = mstD.name
                          }).ToList();
            }
            return result;
        }

        public static bool Add(MstOutletViewModel IsiData)
        {
            MstOutlet Outlet = new MstOutlet();
            Outlet.id = IsiData.id;
            Outlet.name = IsiData.name;
            Outlet.address = IsiData.address;
            Outlet.phone = IsiData.phone;
            Outlet.email = IsiData.email;
            Outlet.provinceId = IsiData.provinceId;
            Outlet.regionId = IsiData.regionId;
            Outlet.districtId = IsiData.districtId;
            Outlet.postalCode = IsiData.postalCode;            
            
            Outlet.createdOn = DateTime.Now;
            Outlet.createdBy = 1;
            Outlet.active = IsiData.active;

            using (POSContext context = new POSContext())
            {
                context.MstOutlets.Add(Outlet);

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

        public static MstOutletViewModel CariID(int id)
        {
            MstOutletViewModel hasilID = new MstOutletViewModel();
            using (POSContext context = new POSContext())
            {
                hasilID = (from mstA in context.MstOutlets
                           where mstA.id == id
                           select new MstOutletViewModel
                           {
                               id = mstA.id,
                               name = mstA.name,
                               address = mstA.address,
                               phone = mstA.phone,
                               email = mstA.email,
                               provinceId = mstA.provinceId,
                               regionId = mstA.regionId,
                               districtId = mstA.districtId,
                               postalCode = mstA.postalCode,
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


        public static bool Update(MstOutletViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                MstOutlet Outlet = context.MstOutlets.Where(s => s.id == IsiData.id).FirstOrDefault();

                Outlet.id = IsiData.id;
                Outlet.name = IsiData.name;
                Outlet.address = IsiData.address;
                Outlet.phone = IsiData.phone;
                Outlet.email = IsiData.email;
                Outlet.provinceId = IsiData.provinceId;
                Outlet.regionId = IsiData.regionId;
                Outlet.districtId = IsiData.districtId;
                Outlet.postalCode = IsiData.postalCode;

                Outlet.modifiedOn = DateTime.Now;
                Outlet.modifiedBy = 1;
                Outlet.active = IsiData.active;

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


        public static bool Delete(MstOutletViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                MstOutlet Outlet = context.MstOutlets.Where(s => s.id == IsiData.id).FirstOrDefault();
                context.MstOutlets.Remove(Outlet);
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
