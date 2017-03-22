using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table("pos_mst_customer")]
    public class MstCustomer
    {
        [Key]
        public long id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string email { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(16)]
        public string phone { get; set; }
        public Nullable<System.DateTime> dob { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(255)]
        public string address { get; set; }
        public long provinceid { get; set; }
        public long regionid { get; set; }
        public long districtid { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public bool active { get; set; }

        public ICollection<MstDistrict> Districts { get; set; }
    }
}
