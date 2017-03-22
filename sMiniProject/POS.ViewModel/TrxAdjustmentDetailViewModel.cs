using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    public class TrxAdjustmentDetailViewModel
    {
        [Key]
        public long id { get; set; }

        [Display(Name = "ID Header")]
        public long headerId { get; set; }

        [Display(Name = "ID Variant")]
        public long variantId { get; set; }

        [Display(Name = "In Stock")]
        public long inStock { get; set; }

        [Display(Name = "Actual Stock")]
        public long actualStock { get; set; }
        
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedBy { get; set; }

        public long StatID { get; set; }
        public string StatName { get; set; }
        public string varName { get; set; }


        public long A { get; set; }
        public string AName { get; set; }
        public long B { get; set; }
        public long C { get; set; }

    }
}
