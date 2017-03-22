using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table("pos_t_adjustment_detail")]
    public class TrxAdjustmentDetail
    {
        [Key]
        public long id { get; set; }
        public long headerId { get; set; }
        public long variantId { get; set; }
        public long inStock { get; set; }
        public long actualStock { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedBy { get; set; }

    }
}
