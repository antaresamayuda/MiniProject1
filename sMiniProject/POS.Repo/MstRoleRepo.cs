using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class MstRoleRepo
    {

        public static List<MstRoleViewModel> GetData() 
        {
            List<MstRoleViewModel> result = new List<MstRoleViewModel>();
            using (POSContext context = new POSContext())  //(_2.Perpustakaan.Context.PerpusContext context = new Context.PerpusContext())
            {
                result = context.MstRoles.Select(x => new MstRoleViewModel()
                 {
                     id = x.id,
                     name = x.name,
                     description = x.description,
                     createdBy = x.createdBy,
                     createdOn = x.createdOn,
                     modifiedBy = x.modifiedBy,
                     modifiedOn = x.modifiedOn,
                     active = x.active
                 }).ToList();
            }
            return result;
        }
          
        public static bool Tambah(MstRoleViewModel model)
        {
            MstRole anggota = new MstRole();
            anggota.id = model.id;
            anggota.name = model.name;
            anggota.description            = model.description;
            anggota.createdBy            = 1;
            anggota.createdOn            = DateTime.Now;
            anggota.active            = model.active;
            

            using (POSContext context = new POSContext())
            {
                context.MstRoles.Add(anggota);
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


        public static bool Update(MstRoleViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstRole anggota = context.MstRoles.Where(s => s.id == model.id).FirstOrDefault();
                //if (anggota != null)
                
                    anggota.id = model.id;
                    anggota.name = model.name;
                    anggota.description = model.description;
                    anggota.modifiedBy = 1;
                    anggota.modifiedOn = DateTime.Now;
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

        public static MstRoleViewModel CariBerdasarkanId(int id)
        {
            MstRoleViewModel hasilnya = new MstRoleViewModel();
            using (POSContext _PerpusContext = new POSContext() )
            {
               hasilnya = (from mstA in _PerpusContext.MstRoles
                            where mstA.id == id
                            select new MstRoleViewModel
                            {
                                id = mstA.id,
                                name = mstA.name,
                                description = mstA.description,
                                active = mstA.active
                                
                            }
                                ).FirstOrDefault();
            }
            return hasilnya ;
        }

      
        public static bool Hapus (MstRoleViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstRole anggota = context.MstRoles.Where(s => s.id == model.id).FirstOrDefault();
                context.MstRoles.Remove(anggota);

                

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
