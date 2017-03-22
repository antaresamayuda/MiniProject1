using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class TrxPoViewModel
    {
        [Key]
        public long id { get; set; }

        [Display(Name = "Outlet ID")]
        public long outletId { get; set; }

        [Display(Name = "Supplier ID")]
        public long supplierId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        [Display(Name = "PO Number")]
        public string poNo { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [Display(Name = "Notes")]
        public string notes { get; set; }

        [Display(Name = "Grand Total")]
        public double grandTotal { get; set; }

        [Display(Name = "Status ID")]
        public long statusId { get; set; }

        public Nullable<long> createdBy { get; set; }

        public Nullable<System.DateTime> createdOn { get; set; }

        public Nullable<long> modifiedBy { get; set; }

        public Nullable<System.DateTime> modifiedOn { get; set; }
    }
}
