using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table("pos_mst_item")]
    public class MstItem
    {
        [Key]
        public long id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string name { get; set; }

        public Nullable<long> categoryId { get; set; }

        public Nullable<long> createdBy { get; set; }

        public Nullable<System.DateTime> createdOn { get; set; }

        public Nullable<long> modifiedBy { get; set; }

        public Nullable<System.DateTime> modifiedOn { get; set; }

        public Boolean active { get; set; }
    }
}
