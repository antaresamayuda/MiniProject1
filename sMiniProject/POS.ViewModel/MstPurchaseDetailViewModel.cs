using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class MstPurchaseDetailViewModel
    {
        [Key]
        [Display(Name = "ID")]
        public long id { get; set; }

        [Display(Name = "Header ID")]
        public long headerId { get; set; }

        [Display(Name = "Variant ID")]
        public long variantId { get; set; }

        [Display(Name = "Request ID")]
        public long requestQty { get; set; }

        [Display(Name = "Unit Cost")]
        public Nullable<double> unitCost { get; set; }

        [Display(Name = "SubTotal")]
        public Nullable<double> subTotal { get; set; }

        [Display(Name = "Created By")]
        public Nullable<long> createdBy { get; set; }

        [Display(Name = "Created On")]
        public Nullable<System.DateTime> createdOn { get; set; }

        [Display(Name = "Modified By")]
        public Nullable<long> modifiedBy { get; set; }

        [Display(Name = "Modified On")]
        public Nullable<System.DateTime> modifiedOn { get; set; }

    }
}
