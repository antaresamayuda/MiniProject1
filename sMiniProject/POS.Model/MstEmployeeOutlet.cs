using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table("pos_employee_outlet")]
    public class MstEmployeeOutlet
    {
        [Key]
        public long id { get; set; }
        public long employeeId { get; set; }
        public long outletId { get; set; }
    }
}
