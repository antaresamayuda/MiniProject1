using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    public class POSContext : DbContext
    {
        public POSContext()
            : base("name=POSContext")
        {

        }

        public DbSet<MstEmployeeOutlet> MstEmployeeOutlets { get; set; }
        public DbSet<MstItem> MstItems { get; set; }
        public DbSet<MstItemVariant> MstItemVariants { get; set; }
        public DbSet<TrxPo> TrxPos { get; set; }
        public DbSet<TrxTransferStock> TrxTransferStocks { get; set; }
        public DbSet<MstItemInventory> MstItemInventorys { get; set; }
        public DbSet<MstOutlet> MstOutlets { get; set; }
        public DbSet<MstStatus> MstStatuss { get; set; }
        public DbSet<TrxTransferStockDetail> TrxTransferStockDetails { get; set; }
        public DbSet<TrxPrHistory> TrxPrHistorys { get; set; }
        public DbSet<TrxPoHistory> TrxPoHistorys { get; set; }
        public DbSet<TrxAdjustmentHistory> TrxAdjustmentHistorys { get; set; }
        public DbSet<TrxTransferStockHistory> TrxTransferStockHistorys { get; set; }
        public DbSet<MstCategory> MstCategorys { get; set; }
        public DbSet<MstCustomer> MstCustomers { get; set; }
        public DbSet<MstDistrict> MstDistricts { get; set; }
        public DbSet<TrxAdjustment> TrxAdjustments { get; set; }
        public DbSet<TrxAdjustmentDetail> TrxAdjustmentDetails { get; set; }
        public DbSet<MstRegion> MstRegions { get; set; }
        public DbSet<MstProvince> MstProvinces { get; set; }
        public DbSet<MstEmployee> MstEmployees { get; set; }
        public DbSet<MstPr> MstPrs { get; set; }
        public DbSet<MstPurchaseDetail> MstPurchaseDetails { get; set; }
        public DbSet<MstSupplier> MstSuppliers { get; set; }
        public DbSet<MstRole> MstRoles { get; set; }
        public DbSet<MstUser> MstUsers { get; set; }
        public DbSet<TrxTSo> TrxTSos { get; set; }
        public DbSet<TrxTSoDetail> TrxTsoDetails { get; set; }

    }
}
