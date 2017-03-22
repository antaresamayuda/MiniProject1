using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class MstItemRepo
    {
        public static List<MstItemViewModel> GetDataItem()
        {
            List<MstItemViewModel> result = new List<MstItemViewModel>();
            using (var context = new POSContext())
            {

                result = (
                            from Item in context.MstItems
                            from ItemVariant in context.MstItemVariants
                            from ItemInventory in context.MstItemInventorys

                            where Item.id == ItemVariant.itemId && ItemVariant.id == ItemInventory.variantId
                            select new MstItemViewModel
                            {
                                id = Item.id,
                                name = Item.name,
                                categoryId = Item.categoryId,
                                active = Item.active,
                                idVariant = ItemVariant.id,
                                namaVariant = ItemVariant.name,
                                InStock = ItemInventory.endingQty
                            }

                ).ToList();
            }
            return result;
        }
        public static List<MstItemViewModel> GetData()
        {
            List<MstItemViewModel> result = new List<MstItemViewModel>();
            using (POSContext context = new POSContext())
            {
                result = context.MstItems.Select(x => new MstItemViewModel()
                {
                    id = x.id,
                    name = x.name,
                    categoryId = x.categoryId,
                    createdBy = x.createdBy,
                    createdOn = x.createdOn,
                    modifiedBy = x.modifiedBy,
                    modifiedOn = x.modifiedOn,
                    active = x.active,

                }).ToList();
            }
            return result;
        }


        public static bool InsertData(Model.POSContext context, ViewModel.MstItemViewModel model)
        {
            bool result = false;
            int HeaderID;
            int IDItemVr;
            POSContext conn = new POSContext();

            var countItem = (from purchase in context.MstItems
                             select new MstItemViewModel()
                                  ).Count();

            if (countItem == 0)
            {
                HeaderID = 1;
            }
            else
            {
                var nilaiMaksimum = conn.MstItems.OrderByDescending(i => i.id).FirstOrDefault();
                HeaderID = 1 + int.Parse(nilaiMaksimum.id.ToString());
            }

            context.MstItems.Add(new Model.MstItem()
            {
                name = model.name,
                categoryId = model.categoryId,
                createdBy = 1,
                createdOn = DateTime.Now,
                active = true
            });


            if (model.DataVariant != null)
            {
                int z = 1;
                foreach (var item in model.DataVariant)
                {
                    var countItemVr = (from purchase in context.MstItemVariants
                                       select new MstItemVariantViewModel()
                                     ).Count();

                    if (countItemVr == 0)
                    {
                        IDItemVr = z;
                    }
                    else
                    {
                        var nilaiMax = conn.MstItemVariants.OrderByDescending(i => i.id).FirstOrDefault();
                        IDItemVr = z + int.Parse(nilaiMax.id.ToString());
                    }

                    context.MstItemVariants.Add(new Model.MstItemVariant()
                    {
                        itemId = HeaderID,
                        name = item.variantName,
                        price = item.price,
                        sku = item.sku,
                        createdBy = 1,
                        createdOn = DateTime.Now,
                        active = true
                    });

                    context.MstItemInventorys.Add(new Model.MstItemInventory()
                    {
                        variantId = IDItemVr,
                        beginning = item.beginning,
                        alertAtQty = item.alertAtQty,
                        adjustmentQty = 0,
                        endingQty = 0,
                        salesOrderQty = 0,
                        transferStockQty = 0,
                        createdBy = 1,
                        createdOn = DateTime.Now
                    });
                    z++;
                }
            }

            try
            {
                context.SaveChanges();
                result = true;
            }
            catch (Exception)
            {

            }
            return result;
        }

        public static bool Update(MstItemViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstItem Item = context.MstItems.Where(s => s.id == model.id).FirstOrDefault();

                Item.id = model.id;
                Item.name = model.name;
                Item.active = model.active;

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

        public static bool UpdateVariant(DTVariants model)
        {
            using (POSContext context = new POSContext())
            {
                MstItemVariant Item = context.MstItemVariants.Where(s => s.id == model.idVr).FirstOrDefault();
                Item.name = model.variantName;
                Item.price = model.price;
                Item.sku = model.sku;

                Item.modifiedOn = DateTime.Now;
                Item.modifiedBy = 1;

                MstItemInventory Inv = context.MstItemInventorys.Where(s => s.id == model.idVr).FirstOrDefault();
                Inv.beginning = model.beginning;
                Inv.alertAtQty = model.alertAtQty;

                Inv.modifiedOn = DateTime.Now;
                Inv.modifiedBy = 1;

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

        public static MstItemViewModel CariBerdasarkanID(int id)
        {
            MstItemViewModel Objecthasilnya = new MstItemViewModel();
            using (POSContext _POSContext = new POSContext())
            {
                Objecthasilnya = (from mstA in _POSContext.MstItems
                                  where mstA.id == id
                                  select new MstItemViewModel
                                  {
                                      id = mstA.id,
                                      name = mstA.name,
                                      categoryId = mstA.categoryId,
                                      active = mstA.active,

                                  }

                            ).FirstOrDefault();
            }
            return Objecthasilnya;
        }

        public static DTVariants CariVariantbyID(int id)
        {
            DTVariants Objecthasilnya = new DTVariants();
            using (POSContext _POSContext = new POSContext())
            {
                Objecthasilnya = (from Vr in _POSContext.MstItemVariants
                                  from Inv in _POSContext.MstItemInventorys
                                  where Vr.id == id && Vr.id == Inv.variantId
                                  select new DTVariants
                                  {
                                      idVr = Vr.id,
                                      variantName = Vr.name,
                                      price = Vr.price,
                                      sku = Vr.sku,
                                      beginning = Inv.beginning,
                                      alertAtQty = Inv.alertAtQty
                                  }

                            ).FirstOrDefault();
            }
            return Objecthasilnya;
        }

        public static bool Hapus(MstItemViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstItem Item = context.MstItems.Where(s => s.id == model.id).FirstOrDefault();
                context.MstItems.Remove(Item);

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

        public static List<MstAllItemVM> GetAllSearch(string strSearch)
        {
            List<MstAllItemVM> result = new List<MstAllItemVM>();
            using (var context = new POSContext())
            {
                result = (from mstS in context.MstItems
                          from mstR in context.MstItemVariants
                          from mstInv in context.MstItemInventorys
                          where mstS.id == mstR.itemId && mstR.name.Contains(strSearch) && mstR.id == mstInv.variantId
                          select new MstAllItemVM
                          {
                              id = mstR.id,
                              name = mstR.name,
                              price = mstR.price,
                              nameItem = mstS.name,
                              IDItem = mstS.id,
                              instock = mstInv.endingQty,
                              alertstock = mstInv.alertAtQty,
                              createdBy = mstS.createdBy,
                              createdOn = mstS.createdOn,
                              modifiedBy = mstS.modifiedBy,
                              modifiedOn = mstS.modifiedOn,
                              active = mstS.active,
                          }).ToList();
            }
            return result;
        }

        public static List<MstAllItemVM> GetCategory(int id)
        {
            List<MstAllItemVM> result = new List<MstAllItemVM>();
            using (var context = new POSContext())
            {
                result = (
                          from itm in context.MstItems
                          from ctg in context.MstCategorys

                          where itm.id == id && itm.categoryId == ctg.id
                          select new MstAllItemVM
                          {
                              nameCategory = ctg.name
                          }
                    ).ToList();
            }
            return result;
        }


        public static List<MstAllItemVM> GetInStock(int id)
        {
            List<MstAllItemVM> result = new List<MstAllItemVM>();
            using (var context = new POSContext())
            {
                result = (
                          from itm in context.MstItemVariants
                          from inv in context.MstItemInventorys

                          where itm.id == inv.variantId && itm.id == id
                          group inv by inv.variantId
                              into g
                              select new MstAllItemVM
                              {
                                  instock = g.Sum(inv => inv.endingQty)
                              }
                    ).ToList();
            }
            return result;
        }


        public static List<MstAllItemVM> GetAlertStock(int id)
        {
            List<MstAllItemVM> result = new List<MstAllItemVM>();
            using (var context = new POSContext())
            {
                result = (
                          from itm in context.MstItemVariants
                          from inv in context.MstItemInventorys

                          where itm.id == inv.variantId && itm.id == id
                          select new MstAllItemVM
                          {
                              instock = inv.endingQty,
                              alertstock = inv.alertAtQty
                          }
                    ).ToList();
            }
            return result;
        }

    }
}
