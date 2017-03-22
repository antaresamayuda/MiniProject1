using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.ViewModel
{
    public class TrxTransferStockDetailViewModel
    {
        [Key]
        public long id { get; set; }
        public long headerId { get; set; }
        public Nullable<int> instock { get; set; }
        public Nullable<long> variantId { get; set; }      
        public Nullable<int> transferQty { get; set; }
        public Nullable<long> createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public Nullable<long> modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedOn { get; set; }
    }
}
