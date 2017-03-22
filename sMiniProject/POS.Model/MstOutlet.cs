using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Model
{
    [Table("pos_mst_outlet")]
    public class MstOutlet
    {
        [Key]
        public long id { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string name { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string address { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(16)]
        public string phone { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string email { get; set; }
        public long provinceId { get; set; }
        public long regionId { get; set; }
        public long districtId { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(6)]
        public string postalCode { get; set; }
        public Nullable<long> createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public Nullable<long> modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedOn { get; set; }
        public bool active { get; set; }

        public ICollection<MstEmployeeOutlet> EmployeeOutlets { get; set; }
    }
}
