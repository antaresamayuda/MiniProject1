using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace POS.ViewModel
{
    public class MstItemInventoryViewModel
    {
        [Key]
        public long id { get; set; }
        public Nullable<long> variantId { get; set; }
        public long outletId { get; set; }
        public long beginning { get; set; }
        public Nullable<long> purchaseQty { get; set; }
        public Nullable<long> salesOrderQty { get; set; }
        public Nullable<long> transferStockQty { get; set; }
        public Nullable<long> adjustmentQty { get; set; }
        public long endingQty { get; set; }
        public long alertAtQty { get; set; }
        public Nullable<long> createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public Nullable<long> modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedOn { get; set; }




    }
    
}