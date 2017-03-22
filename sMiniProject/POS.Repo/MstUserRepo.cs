using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class MstUserRepo
    {

    public static List<MstUserViewModel> GetData()
        {
            List<MstUserViewModel> result = new List<MstUserViewModel>();
            using (POSContext context = new POSContext())  //(_2.Perpustakaan.Context.PerpusContext context = new Context.PerpusContext())
            {
                result = context.MstUsers.Select(x => new MstUserViewModel()
                 {
                     id = x.id,
                     username = x.username,
                     password = x.password,
                     roleId = x.roleId,
                     createdBy = x.createdBy,
                     createdOn = x.createdOn,
                     modifiedBy = x.modifiedBy,
                     modifiedOn = x.ModifiedOn,
                     active = x.active
                     
                 }).ToList();
            };
            return result;
        }
          
        public static bool Tambah(MstUserViewModel model)
        {
            MstUser anggota = new MstUser();
            anggota.id = model.id;
            anggota.username = model.username;
            anggota.password            = model.password;
            anggota.roleId            = model.roleId;
            anggota.createdBy            = 1;
            anggota.createdOn            = DateTime.Now;
            anggota.active            = model.active;

            using (POSContext context = new POSContext())
            {
                context.MstUsers.Add(anggota);
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


        public static bool Update(MstUserViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstUser anggota = context.MstUsers.Where(s => s.id == model.id).FirstOrDefault();
                //if (anggota != null)
                
                    anggota.id = model.id;
                    anggota.username = model.username;
                    anggota.password = model.password;
                    anggota.roleId = model.roleId;
                    anggota.modifiedBy = 1;
                    anggota.ModifiedOn = DateTime.Now;
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

        public static MstUserViewModel CariBerdasarkanId(int id)
        {
            MstUserViewModel hasilnya = new MstUserViewModel();
            using (POSContext _PerpusContext = new POSContext() )
            {
               hasilnya = (from mstA in _PerpusContext.MstUsers
                            where mstA.id == id
                            select new MstUserViewModel
                            {
                                id = mstA.id,
                                username = mstA.username,
                                password = mstA.password,
                                roleId = mstA.roleId,
                                active = mstA.active
                            }
                                ).FirstOrDefault();
            }
            return hasilnya ;
        }

      
        public static bool Hapus (MstUserViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstUser anggota = context.MstUsers.Where(s => s.id == model.id).FirstOrDefault();
                context.MstUsers.Remove(anggota);

                

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
