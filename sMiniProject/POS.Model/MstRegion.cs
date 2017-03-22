using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table("pos_mst_region")]
    public class MstRegion
    {
        [Key]
        public long id { get; set; }
        public long provinceId { get; set; }
        [Column(TypeName="VARCHAR")]
        [StringLength(50)]
        public string name { get; set; }
        public Nullable<long> createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public Nullable<long> modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedOn { get; set; }
        public bool active { get; set; }
    }
}
