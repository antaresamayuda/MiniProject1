using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class MstRoleViewModel
    {
        [Key]
        public long id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Nama")]
        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Deskripsi")]
        [StringLength(255)]
        public string description { get; set; }
        public Nullable<long> createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public Nullable<long> modifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Boolean active { get; set; }





        public DateTime? modifiedOn { get; set; }
    }
}
