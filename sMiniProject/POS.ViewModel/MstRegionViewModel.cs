using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class MstRegionViewModel
    {
        [Key]
        [Display(Name = "ID")]
        public long id { get; set; }

        [Display(Name = "Province ID")]
        public long provinceId { get; set; }

        [Display(Name="Name")]
        [Column(TypeName="VARCHAR")]
        [StringLength(50)]
        public string name { get; set; }

        [Display(Name = "Created By")]
        public Nullable<long> createdBy { get; set; }

        [Display(Name = "Created On")]
        public Nullable<System.DateTime> createdOn { get; set; }

        [Display(Name = "Modified By")]
        public Nullable<long> modifiedBy { get; set; }

        [Display(Name = "Modified On")]
        public Nullable<System.DateTime> modifiedOn { get; set; }

        [Display(Name = "Active ?")]
        public bool active { get; set; }
    }
}
