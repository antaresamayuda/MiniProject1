using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class MstEmployeeOutletViewModel
    {
        [Key]
        public long id { get; set; }
        [Display(Name="Employe ID")]
        public long employeeId { get; set; }
        [Display(Name = "Outlet ID")]
        public long outletId { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string name { get; set; }
    }
}
