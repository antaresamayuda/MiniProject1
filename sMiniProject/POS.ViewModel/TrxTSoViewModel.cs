using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class TrxTSoViewModel
    {
        [Key]
        public long id { get; set; }
        [Display(Name = "Customer Id")]
        public long customerId { get; set; }
        [Display(Name = "Grand Total")]
        public double grandTotal { get; set; }
        public Nullable<long> createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public Nullable<long> modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedOn { get; set; }
    }
}
