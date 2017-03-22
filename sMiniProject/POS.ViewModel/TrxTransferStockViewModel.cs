using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class TrxTransferStockViewModel
    {
        [Key]
        public long id { get; set; }

        [Display(Name = "From Outlet")]
        public long fromOutlet { get; set; }

        [Display(Name = "To Outlet")]
        public long toOutlet { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [Display(Name = "Notes")]
        public string notes { get; set; }

        public Nullable<long> createdBy { get; set; }

        public Nullable<System.DateTime> createdOn { get; set; }

        public Nullable<long> modifiedBy { get; set; }

        public Nullable<System.DateTime> modifiedOn { get; set; }
    }
}
