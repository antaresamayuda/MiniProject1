using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.ViewModel;
using POS.Model;

namespace POS.Repo
{
    public class MstSupplierRepo
    {
        public static bool Tambah (MstSupplierViewModel model)
        {
            MstSupplier tambah = new MstSupplier();
            tambah.id = model.id;
            tambah.name = model.name;
            tambah.address = model.address;
            tambah.phone = model.phone;
            tambah.email = model.email;
            tambah.provinceId = model.provinceId;
            tambah.regionId = model.regionId;
            tambah.districtId = model.districtId;
            tambah.postalCode = model.postalCode;
            tambah.createdOn = DateTime.Now;
            tambah.createdBy = 1;
            tambah.active = true;
            
            using (POSContext context = new POSContext())
            {
                context.MstSuppliers.Add(tambah);
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


            //return true;
        }

        public static List<MstSupplierViewModel> GetData()
        {
            List<MstSupplierViewModel> result = new List<MstSupplierViewModel>();
            using (POSContext context = new POSContext())  //(_2.Perpustakaan.Context.PerpusContext context = new Context.PerpusContext())
            {
                result = (from mstS in context.MstSuppliers
                          from mstP in context.MstProvinces
                          from mstR in context.MstRegions
                          from mstD in context.MstDistricts
                          where mstS.provinceId== mstP.id && mstS.regionId==mstR.id && mstS.districtId==mstD.id
                          select new MstSupplierViewModel
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
            };
            return result;
        } 

        public static bool Update(MstSupplierViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstSupplier anggota = context.MstSuppliers.Where(s => s.id == model.id).FirstOrDefault();
                //if (anggota != null)
                
                    anggota.id = model.id;
                    anggota.name = model.name;
                    anggota.address = model.address;
                    anggota.phone = model.phone;
                    anggota.email = model.email;
                    anggota.provinceId = model.provinceId;
                    anggota.regionId = model.regionId;
                    anggota.districtId = model.districtId;
                    anggota.postalCode = model.postalCode;
                    anggota.modifiedOn = DateTime.Now;
                    anggota.modifiedBy = 1;
                    anggota.active = model.active;                   
                                
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

        public static MstSupplierViewModel CariBerdasarkanId(int id)
        {
            MstSupplierViewModel hasilnya = new MstSupplierViewModel();
            using (POSContext _PerpusContext = new POSContext())
            {
                hasilnya = (from mstA in _PerpusContext.MstSuppliers
                            where mstA.id == id
                            select new MstSupplierViewModel
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
                                active = mstA.active
                            }
                                 ).FirstOrDefault();
            }
            return hasilnya;
        }


        public static bool Hapus(MstSupplierViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstSupplier anggota = context.MstSuppliers.Where(s => s.id == model.id).FirstOrDefault();
                context.MstSuppliers.Remove(anggota);



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


        public static List<MstSupplierViewModel> GetAllSearch(string strSearch)
        {
            List<MstSupplierViewModel> result = new List<MstSupplierViewModel>();
            using (var context = new POSContext())
            {
                result = (from mstS in context.MstSuppliers
                          from mstP in context.MstProvinces
                          from mstR in context.MstRegions
                          from mstD in context.MstDistricts
                          where mstS.provinceId == mstP.id && mstS.regionId == mstR.id && mstS.districtId == mstD.id && mstS.name.Contains(strSearch)
                          select new MstSupplierViewModel
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
    }
}
