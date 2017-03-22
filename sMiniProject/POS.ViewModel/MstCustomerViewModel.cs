using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    public class MstCustomerViewModel
    {
        [Key]
        public long id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string name { get; set; }
        [Display(Name = "Nama Customer")]

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string email { get; set; }
        [Display(Name = "Email")]

        [Column(TypeName = "Varchar")]
        [StringLength(16)]
        public string phone { get; set; }
        [Display(Name = "No Handphone")]
        public Nullable<System.DateTime> dob { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(255)]
        public string address { get; set; }
        [Display(Name = "Alamat")]
        public long provinceid { get; set; }
        [Display(Name = "ID Provinsi")]
        public long regionid { get; set; }
        [Display(Name = "ID Region")]
        public long districtid { get; set; }
        [Display(Name = "ID District")]
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public bool active { get; set; }

    }
}
