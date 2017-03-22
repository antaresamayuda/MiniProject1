using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class TrxPoRepo
    {
        public static List<TrxPoViewModel> GetData()
        {
            List<TrxPoViewModel> result = new List<TrxPoViewModel>();
            using (POSContext context = new POSContext())
            {
                result = context.TrxPos.Select(x => new TrxPoViewModel()
                {
                    id = x.id,
                    outletId = x.outletId,
                    supplierId = x.supplierId,
                    poNo = x.poNo,
                    notes = x.notes,
                    grandTotal = x.grandTotal,
                    statusId = x.statusId,
                    createdBy = x.createdBy,
                    createdOn = x.createdOn,
                    modifiedBy = x.modifiedBy,
                    modifiedOn = x.modifiedOn,

                }).ToList();
            }
            return result;
        }

        public static bool Tambah(TrxPoViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                TrxPo Item = new TrxPo();
                Item.id = model.id;
                Item.outletId = model.outletId;
                Item.supplierId = model.supplierId;
                Item.poNo = model.poNo;
                Item.notes = model.notes;
                Item.grandTotal = model.grandTotal;
                Item.statusId = model.statusId;

                Item.createdOn = DateTime.Now;
                Item.createdBy = 1;

                context.TrxPos.Add(Item);
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

        public static bool Update(TrxPoViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                TrxPo Item = context.TrxPos.Where(s => s.id == model.id).FirstOrDefault();

                Item.id = model.id;
                Item.outletId = model.outletId;
                Item.supplierId = model.supplierId;
                Item.poNo = model.poNo;
                Item.notes = model.notes;
                Item.grandTotal = model.grandTotal;
                Item.statusId = model.statusId;

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

        public static TrxPoViewModel CariBerdasarkanID(int id)
        {
            TrxPoViewModel Objecthasilnya = new TrxPoViewModel();
            using (POSContext _POSContext = new POSContext())
            {
                Objecthasilnya = (from mstA in _POSContext.TrxPos
                                  where mstA.id == id
                                  select new TrxPoViewModel
                                  {
                                      id = mstA.id,
                                      outletId = mstA.outletId,
                                      supplierId = mstA.supplierId,
                                      poNo = mstA.poNo,
                                      notes = mstA.notes,
                                      grandTotal = mstA.grandTotal,
                                      statusId = mstA.statusId,

                                  }

                            ).FirstOrDefault();
            }
            return Objecthasilnya;
        }

        public static bool Hapus(TrxPoViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                TrxPo Item = context.TrxPos.Where(s => s.id == model.id).FirstOrDefault();
                context.TrxPos.Remove(Item);

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
