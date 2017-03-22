using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table("pos_mst_item_variant")]
    public class MstItemVariant
    {
        [Key]
        public long id { get; set; }

        public long itemId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [Display(Name="Nama")]
        public string name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string sku { get; set; }

        [Display (Name="Harga")]
        public double price { get; set; }

        public Nullable<long> createdBy { get; set; }

        public Nullable<System.DateTime> createdOn { get; set; }

        public Nullable<long> modifiedBy { get; set; }

        public Nullable<System.DateTime> modifiedOn { get; set; }

        public Boolean active { get; set; }
    }
}
