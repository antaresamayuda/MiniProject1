using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class MstPrViewModel
    {
        [Key]
        [Display(Name="ID")]
        public long id { get; set; }

        [Display(Name = "Outlet ID")]
        public long outletId { get; set; }

        [Display(Name = "Ready Time")]
        public Nullable<DateTime> readyTime { get; set; }

        [Display(Name = "PR No")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string prNo { get; set; }

        [Display(Name = "Notes")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string notes { get; set; }

        [Display(Name = "Status ID")]
        public long statusId { get; set; }

        [Display(Name = "Created By")]
        public Nullable<long> createdBy { get; set; }

        [Display(Name = "Created On")]
        public Nullable<System.DateTime> createdOn { get; set; }

        [Display(Name = "Modified By")]
        public Nullable<long> modifiedBy { get; set; }

        [Display(Name = "Modified On")]
        public Nullable<System.DateTime> modifiedOn { get; set; }

    }
}
