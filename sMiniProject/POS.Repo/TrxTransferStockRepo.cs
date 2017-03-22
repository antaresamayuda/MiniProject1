using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

//edit buat ngetest push and pull tapi coba terus sampe bisa



namespace POS.Repo
{
    public class TrxTransferStockRepo
    {
        public static List<TrxTransferStockViewModel> GetData()
        {
            List<TrxTransferStockViewModel> result = new List<TrxTransferStockViewModel>();
            using (POSContext context = new POSContext())
            {
                result = context.TrxTransferStocks.Select(x => new TrxTransferStockViewModel()
                {
                    id = x.id,
                    fromOutlet = x.fromOutlet,
                    toOutlet = x.toOutlet,
                    notes = x.notes,
                    createdBy = x.createdBy,
                    createdOn = x.createdOn,
                    modifiedBy = x.modifiedBy,
                    modifiedOn = x.modifiedOn,                  

                }).ToList();
            }
            return result;
        }

        public static bool Tambah(TrxTransferStockViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                TrxTransferStock Item = new TrxTransferStock();
                Item.id = model.id;
                Item.fromOutlet = model.fromOutlet;
                Item.toOutlet = model.toOutlet;
                Item.notes = model.notes;

                Item.createdOn = DateTime.Now;
                Item.createdBy = 1;

                context.TrxTransferStocks.Add(Item);
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

        public static bool Update(TrxTransferStockViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                TrxTransferStock Item = context.TrxTransferStocks.Where(s => s.id == model.id).FirstOrDefault();

                Item.id = model.id;
                Item.fromOutlet = model.fromOutlet;
                Item.toOutlet = model.toOutlet;
                Item.notes = model.notes;

                Item.modifiedOn = DateTime.Now;
                Item.modifiedBy = 1;

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

        public static TrxTransferStockViewModel CariBerdasarkanID(int id)
        {
            TrxTransferStockViewModel Objecthasilnya = new TrxTransferStockViewModel();
            using (POSContext _POSContext = new POSContext())
            {
                Objecthasilnya = (from mstA in _POSContext.TrxTransferStocks
                                  where mstA.id == id
                                  select new TrxTransferStockViewModel
                                  {
                                      id = mstA.id,
                                      fromOutlet = mstA.fromOutlet,
                                      toOutlet = mstA.toOutlet,
                                      notes = mstA.notes,

                                  }

                            ).FirstOrDefault();
            }
            return Objecthasilnya;
        }

        public static bool Hapus(TrxTransferStockViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                TrxTransferStock Item = context.TrxTransferStocks.Where(s => s.id == model.id).FirstOrDefault();
                context.TrxTransferStocks.Remove(Item);

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
