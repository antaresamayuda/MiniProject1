using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class MstItemVariantRepo
    {
        public static List<MstItemVariantViewModel> GetData()
        {
            List<MstItemVariantViewModel> result = new List<MstItemVariantViewModel>();
            using (POSContext context = new POSContext())
            {
                result = context.MstItemVariants.Select(x => new MstItemVariantViewModel()
                {
                    id = x.id,
                    itemId = x.itemId,
                    name = x.name,
                    sku = x.sku,
                    price = x.price,
                    createdBy = x.createdBy,
                    createdOn = x.createdOn,
                    modifiedBy = x.modifiedBy,
                    modifiedOn = x.modifiedOn,
                    active = x.active,

                }).ToList();
            }
            return result;
        }

        public static bool Tambah(MstItemVariantViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstItemVariant ItemVariant = new MstItemVariant();
                ItemVariant.id = model.id;
                ItemVariant.itemId = model.itemId;
                ItemVariant.name = model.name;
                ItemVariant.sku = model.sku;
                ItemVariant.price = model.price;
                ItemVariant.active = model.active;

                ItemVariant.createdOn = DateTime.Now;
                ItemVariant.createdBy = 1;

                context.MstItemVariants.Add(ItemVariant);
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

        public static bool Update(MstItemVariantViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstItemVariant ItemVariant = context.MstItemVariants.Where(s => s.id == model.id).FirstOrDefault();

                ItemVariant.id = model.id;
                ItemVariant.itemId = model.itemId;
                ItemVariant.name = model.name;
                ItemVariant.sku = model.sku;
                ItemVariant.price = model.price;
                ItemVariant.active = model.active;

                ItemVariant.modifiedOn = DateTime.Now;
                ItemVariant.modifiedBy = 1;

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

        public static MstItemVariantViewModel CariBerdasarkanID(int id)
        {
            MstItemVariantViewModel Objecthasilnya = new MstItemVariantViewModel();
            using (POSContext _POSContext = new POSContext())
            {
                Objecthasilnya = (from mstA in _POSContext.MstItemVariants
                                  where mstA.id == id
                                  select new MstItemVariantViewModel
                                  {
                                      id = mstA.id,
                                      itemId = mstA.itemId,
                                      name = mstA.name,
                                      sku = mstA.sku,
                                      price = mstA.price,
                                      active = mstA.active,

                                  }

                            ).FirstOrDefault();
            }
            return Objecthasilnya;
        }

        public static bool Hapus(MstItemVariantViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstItemVariant ItemVariant = context.MstItemVariants.Where(s => s.id == model.id).FirstOrDefault();
                context.MstItemVariants.Remove(ItemVariant);

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
