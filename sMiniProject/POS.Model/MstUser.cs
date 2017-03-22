using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table ("pos_mst_user")]
    public class MstUser
    {
        [Key]
        public long id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Display (Name = "User Name")]
        [StringLength(50)]
        public string username { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Password")]
        [StringLength(255)]
        public string password { get; set; }
        public long roleId { get; set; }
        public long employeeId { get; set; }
        public Nullable<long> createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public Nullable<long> modifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Boolean active { get; set; }

    }
}
