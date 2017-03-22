using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class MstAllItemVM
    {
        [Key]
        public long id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [Display(Name="Name")]
        public string name { get; set; }

        [Display(Name = "Category ID")]
        public string nameItem { get; set; }
        public long IDItem { get; set; }

        public Nullable<long> createdBy { get; set; }

        public Nullable<System.DateTime> createdOn { get; set; }

        public Nullable<long> modifiedBy { get; set; }

        public Nullable<System.DateTime> modifiedOn { get; set; }

        [Display(Name = "Active")]
        public Boolean active { get; set; }

        public long instock { get; set; }
        public long alertstock { get; set; }
        public double price { get; set; }

        public string nameCategory { get; set; }
    }
}
