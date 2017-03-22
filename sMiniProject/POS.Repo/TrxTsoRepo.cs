using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.ViewModel;
using POS.Model;

namespace POS.Repo
{
    public class TrxTsoRepo
    {

        public static List<TrxTSoViewModel> GetData()
        {
            List<TrxTSoViewModel> result = new List<TrxTSoViewModel>();
            using (POSContext context = new POSContext())  //(_2.Perpustakaan.Context.POSContext context = new Context.POSContext())
            {
                result = context.TrxTSos.Select(x => new TrxTSoViewModel()
                 {
                     id = x.id,
                     customerId = x.customerId,
                     grandTotal = x.grandTotal,
                     createdBy = x.createdBy,
                     createdOn = x.createdOn,
                     modifiedBy = x.modifiedBy,
                     modifiedOn = x.modifiedOn
                 }).ToList();
            };
            return result;
        }

        public static bool Tambah(TrxTSoViewModel model)
        {
            TrxTSo anggota = new TrxTSo();
            anggota.id = model.id;
            anggota.customerId = model.customerId;
            anggota.grandTotal = model.grandTotal;
            anggota.createdBy = 1;
            anggota.createdOn = DateTime.Now;
            

            using (POSContext context = new POSContext())
            {
                context.TrxTSos.Add(anggota);
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


        public static bool Update(TrxTSoViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                TrxTSo anggota = context.TrxTSos.Where(s => s.id == model.id).FirstOrDefault();
                //if (anggota != null)

                anggota.id = model.id;
                anggota.customerId = model.customerId;
                anggota.grandTotal = model.grandTotal;
                anggota.modifiedBy = 1;
                anggota.modifiedOn = DateTime.Now;
                
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

        public static TrxTSoViewModel CariBerdasarkanId(int id)
        {
            TrxTSoViewModel hasilnya = new TrxTSoViewModel();
            using (POSContext _POSContext = new POSContext())
            {
                hasilnya = (from mstA in _POSContext.TrxTSos
                            where mstA.id == id
                            select new TrxTSoViewModel
                            {
                                id = mstA.id,
                                customerId = mstA.customerId,
                                grandTotal = mstA.grandTotal
                                
                            }
                                 ).FirstOrDefault();
            }
            return hasilnya;
        }


        public static bool Hapus(TrxTSoViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                TrxTSo anggota = context.TrxTSos.Where(s => s.id == model.id).FirstOrDefault();
                context.TrxTSos.Remove(anggota);



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
