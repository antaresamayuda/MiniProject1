using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Model
{
    [Table("pos_mst_status")]
    public class MstStatus
    {
        [Key]
        public long id { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string name { get; set; }
        public Nullable<long> createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public Nullable<long> modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedOn { get; set; }
        public bool active { get; set; }
    }
}
