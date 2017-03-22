using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class TrxTSoDetailRepo
    {

        public static List<TrxTSoDetailViewModel> GetData()
        {
            List<TrxTSoDetailViewModel> result = new List<TrxTSoDetailViewModel>();
            using (POSContext context = new POSContext())  //(_2.Perpustakaan.Context.POSContext context = new Context.POSContext())
            {
                result = context.TrxTsoDetails.Select(x => new TrxTSoDetailViewModel()
                 {
                     id = x.id,
                     headerId = x.headerId,
                     variantId = x.variantId,
                     qty = x.qty,
                     unitPrice = x.unitPrice,
                     subTotal = x.subTotal,
                     createdBy = x.createdBy,
                     createdOn = x.createdOn,
                     modifiedBy = x.modifiedBy,
                     modifiedOn = x.modifiedOn
                 }).ToList();
            return result;
        }
        }

        public static bool Tambah(TrxTSoDetailViewModel model)
        {
            TrxTSoDetail anggota = new TrxTSoDetail();
            anggota.id = model.id;
            anggota.headerId = model.headerId;
            anggota.variantId = model.variantId;
            anggota.qty = model.qty;
            anggota.unitPrice = model.unitPrice;
            anggota.subTotal = model.subTotal;
            anggota.createdBy = 1;
            anggota.createdOn = DateTime.Now;
            

            using (POSContext context = new POSContext())
            {
                context.TrxTsoDetails.Add(anggota);
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


        public static bool Update(TrxTSoDetailViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                TrxTSoDetail anggota = context.TrxTsoDetails.Where(s => s.id == model.id).FirstOrDefault();
                //if (anggota != null)

                anggota.id = model.id;
                anggota.headerId = model.headerId;
                anggota.variantId = model.variantId;
                anggota.qty = model.qty;
                anggota.unitPrice = model.unitPrice;
                anggota.subTotal = model.subTotal;
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

        public static TrxTSoDetailViewModel CariBerdasarkanId(int id)
        {
            TrxTSoDetailViewModel hasilnya = new TrxTSoDetailViewModel();
            using (POSContext _POSContext = new POSContext())
            {
                hasilnya = (from mstA in _POSContext.TrxTsoDetails
                            where mstA.id == id
                            select new TrxTSoDetailViewModel
                            {
                                id = mstA.id,
                                headerId = mstA.headerId,
                                variantId = mstA.variantId,
                                qty = mstA.qty,
                                unitPrice = mstA.unitPrice,
                                subTotal = mstA.subTotal
                            }
                                 ).FirstOrDefault();
            }
            return hasilnya;
        }


        public static bool Hapus(TrxTSoDetailViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                TrxTSoDetail anggota = context.TrxTsoDetails.Where(s => s.id == model.id).FirstOrDefault();
                context.TrxTsoDetails.Remove(anggota);



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
