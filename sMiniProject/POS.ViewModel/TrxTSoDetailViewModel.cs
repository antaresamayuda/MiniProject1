using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class TrxTSoDetailViewModel
    {
        [Key]
        public long id { get; set; }
        [Display(Name = "Header Id")]
        public long headerId { get; set; }
        [Display(Name = "Variant Id")]
        public long variantId { get; set; }
        [Display(Name = "Qty")]
        public int qty { get; set; }
        [Display(Name = "Unit Price")]
        public double unitPrice { get; set; }
        [Display(Name = "Sub Total")]
        public double subTotal { get; set; }
        public Nullable<long> createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public Nullable<long> modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedOn { get; set; }
    }
}
