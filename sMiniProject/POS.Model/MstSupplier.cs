using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table ("pos_mst_supplier")]
    public class MstSupplier
    {
        [Key]
        public long id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Nama")]
        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Alamat")]
        [StringLength(255)]
        public string address { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Display(Name = "No Telp")]
        public string phone { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Email")]
        public string  email { get; set; }
        [Display(Name = "Province Id")]
        public long provinceId { get; set; }

        [Display(Name = "Region Id")]
        public long regionId { get; set; }

        [Display(Name = "District Id")]
        public long districtId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Postal Code")]
        [StringLength(50)]
        public string postalCode { get; set; }
        public Nullable< long> createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public Nullable<long> modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedOn { get; set; }
        public Boolean active { get; set; }


    }
}
