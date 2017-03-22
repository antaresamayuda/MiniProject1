using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    public class TrxAdjustmentViewModel
    {
        [Key]
        public long id { get; set; }

        [Display(Name = "ID Outlet")]
        public long outletId { get; set; }

        [Display(Name = "Notes")]
        [Column(TypeName = "Varchar")]
        [StringLength(255)]
        public string notes { get; set; }

        [Display(Name = "ID Status")]
        public long statusId { get; set; }
        
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedBy { get; set; }

        public string StatusName { get; set; }

       
        public long A { get; set; }
        public string AName { get; set; }
        public long B { get; set; }
        public long C { get; set; }


        public List<DetailAdjust> inventory { get; set; }

        

    }

    public class DetailAdjust
    {
        public long variantId { get; set; }
        public long InStock { get; set; }
        public long AdjustQty { get; set; }
    }

}
