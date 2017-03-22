using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class MstItemInventoryRepo
    {
        public static List<MstItemInventoryViewModel> GetData()
        {
            List<MstItemInventoryViewModel> result = new List<MstItemInventoryViewModel>();
            using (POSContext context = new POSContext())
            {
                result = context.MstItemInventorys.Select(x => new MstItemInventoryViewModel()
                {
                    id = x.id,
                    variantId = x.variantId,
                    outletId = x.outletId,
                    beginning = x.beginning,
                    purchaseQty = x.purchaseQty,
                    salesOrderQty = x.salesOrderQty,
                    transferStockQty = x.transferStockQty,
                    adjustmentQty = x.adjustmentQty,
                    endingQty = x.endingQty,
                    alertAtQty = x.alertAtQty,
                    createdBy= x.createdBy,
                    createdOn = x.createdOn,
                    modifiedBy = x.modifiedBy,
                    modifiedOn = x.modifiedOn

                }).ToList();
            }
            return result;
        }

        public static bool Add(MstItemInventoryViewModel IsiData)
        {
            MstItemInventory Inventory = new MstItemInventory();
            Inventory.id = IsiData.id;
            Inventory.variantId = IsiData.variantId;
            Inventory.outletId = IsiData.outletId;
            //Inventory.beginning = IsiData.beginning;
            //Inventory.purchaseQty = IsiData.purchaseQty;
            //Inventory.salesOrderQty = IsiData.salesOrderQty;
            //Inventory.transferStockQty = IsiData.transferStockQty;
            //Inventory.adjustmentQty = IsiData.adjustmentQty;
            //Inventory.endingQty = IsiData.endingQty;
            //Inventory.alertAtQty = IsiData.alertAtQty;

            Inventory.createdOn = DateTime.Now;
            Inventory.createdBy = 1;

            using (POSContext context = new POSContext())
            {
                context.MstItemInventorys.Add(Inventory);

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

        public static MstItemInventoryViewModel CariID(int id)
        {
            MstItemInventoryViewModel hasilID = new MstItemInventoryViewModel();
            using (POSContext context = new POSContext())
            {
                hasilID = (from mstA in context.MstItemInventorys
                           where mstA.id == id
                           select new MstItemInventoryViewModel
                           {
                               id = mstA.id,
                               variantId = mstA.variantId,
                               outletId = mstA.outletId,
                               beginning = mstA.beginning,
                               purchaseQty = mstA.purchaseQty,
                               salesOrderQty = mstA.salesOrderQty,
                               transferStockQty = mstA.transferStockQty,
                               adjustmentQty = mstA.adjustmentQty,
                               endingQty = mstA.endingQty,
                               alertAtQty = mstA.alertAtQty,
                               createdBy = mstA.createdBy,
                               createdOn = mstA.createdOn,
                               modifiedBy =mstA.modifiedBy,
                               modifiedOn = mstA.modifiedOn
                           }
                           ).FirstOrDefault();
            }
            return hasilID;
        }
        public static bool Update(MstItemInventoryViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                MstItemInventory Inventory = context.MstItemInventorys.Where(s => s.id == IsiData.id).FirstOrDefault();

                Inventory.id = IsiData.id;
                Inventory.variantId = IsiData.variantId;
                Inventory.outletId = IsiData.outletId;
                //Inventory.beginning = IsiData.beginning;
                //Inventory.purchaseQty = IsiData.purchaseQty;
                //Inventory.salesOrderQty = IsiData.salesOrderQty;
                //Inventory.transferStockQty = IsiData.transferStockQty;
                //Inventory.adjustmentQty = IsiData.adjustmentQty;
                //Inventory.endingQty = IsiData.endingQty;
                //Inventory.alertAtQty = IsiData.alertAtQty;

                Inventory.modifiedOn = DateTime.Now;
                Inventory.modifiedBy = 1;
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


        public static bool Delete(MstItemInventoryViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                MstItemInventory Kecamatan = context.MstItemInventorys.Where(s => s.id == IsiData.id).FirstOrDefault();
                context.MstItemInventorys.Remove(Kecamatan);
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
