using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table("pos_t_pr")]
    public class MstPr
    {
        [Key]
        public long id { get; set; }
        public long outletId { get; set; }
        public Nullable<DateTime> readyTime { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string prNo { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string notes { get; set; }

        public long statusId { get; set; }
        public Nullable<long> createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public Nullable<long> modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedOn { get; set; }

    }
}
