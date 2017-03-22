using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class MstSupplierViewModel
    {
        public long id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Address")]
        [StringLength(255)]
        public string address { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Phone")]
        public string phone { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Email")]
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
        [StringLength(50)]
        public string postalCode { get; set; }
        public Nullable<long> createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public Nullable<long> modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedOn { get; set; }
        public Boolean active { get; set; }

        
    }
}
