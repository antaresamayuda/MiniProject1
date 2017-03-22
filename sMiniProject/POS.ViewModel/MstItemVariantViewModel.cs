using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class MstItemVariantViewModel
    {
        [Key]
        public long id { get; set; }

        [Display(Name = "Item ID")]
        public long itemId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Display(Name = "SKU")]
        public string sku { get; set; }

        [Display(Name = "Price")]
        public double price { get; set; }

        public Nullable<long> createdBy { get; set; }

        public Nullable<System.DateTime> createdOn { get; set; }

        public Nullable<long> modifiedBy { get; set; }

        public Nullable<System.DateTime> modifiedOn { get; set; }

        public Boolean active { get; set; }
    }
}
