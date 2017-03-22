using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class MstAllEmOuVM
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

        [Display(Name = "Active ?")]
        public bool active { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Display(Name = "Active ?")]
        public string nameOu { get; set; }


    }
}
