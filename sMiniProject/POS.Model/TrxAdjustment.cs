using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table("pos_t_adjustment")]
    public class TrxAdjustment
    {
        [Key]
        public long id { get; set; }
        public long outletId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(255)]
        public string notes { get; set; }

        public long statusId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedBy { get; set; }



    }
}
