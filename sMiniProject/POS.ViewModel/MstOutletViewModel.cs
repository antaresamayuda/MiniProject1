using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.ViewModel
{
    public class MstOutletViewModel
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
        [Display(Name = "Provinsi")]
        public string nameProvinsi { get; set; }

        [Display(Name = "Region Id")]
        public long regionId { get; set; }

        [Display(Name = "Region")]
        public string nameRegion { get; set; }

        [Display(Name = "District Id")]
        public long districtId { get; set; }

        [Display(Name = "District")]
        public string nameDistrict { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(6)]
        public string postalCode { get; set; }
        public Nullable<long> createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public Nullable<long> modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedOn { get; set; }
        public bool active { get; set; }

    }
}
