using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class MstEmployeeViewModel
    {
        [Key]
        [Display(Name="ID")]
        public long id { get; set; }

        [Display(Name = "First Name")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string lastName { get; set; }

        [Display(Name="Email")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string email { get; set; }

        [Display(Name = "Title")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string title { get; set; }

        [Display(Name = "Have Acount ?")]
        public bool haveAccount { get; set; }

        [Display(Name = "Created By")]
        public Nullable<long> createdBy { get; set; }

        [Display(Name = "Created On")]
        public Nullable<System.DateTime> createdOn { get; set; }

        [Display(Name = "Modified By")]
        public Nullable<long> modifiedBy { get; set; }

        [Display(Name = "Modified On")]
        public Nullable<System.DateTime> modifiedOn { get; set; }

        [Display(Name = "Active ?")]
        public bool active { get; set; }

        public List<MstEmployeeOutletViewModel> Detail { get; set; }
        public List<MstUserViewModel> UserDetail { get; set; }
        public List<int> IDOutlet { get; set; }


        ///view editor untuk user

        [Column(TypeName = "VARCHAR")]
        [Display(Name = "User Name")]
        [StringLength(50)]
        public string username { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Password")]
        [StringLength(255)]
        public string password { get; set; }
        [Display(Name = "Role Id")]
        public long roleId { get; set; }

        ///view role
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Nama")]
        [StringLength(50)]
        public string nameRO { get; set; }
    }
}
