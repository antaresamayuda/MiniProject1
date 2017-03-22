using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table("pos_mst_employee")]
    public class MstEmployee
    {
        [Key]
        public long id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string firstName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string lastName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string email { get; set; }
        
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string title { get; set; }

        public bool haveAccount { get; set; }
        public Nullable<long> createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public Nullable<long> modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedOn { get; set; }
        public bool active { get; set; }

        //public string cek { get; set; }


        public ICollection<MstEmployeeOutlet> EmployeeOutlets { get; set; }
    }
}
