using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.ViewModel
{
    public class TrxAdjustmentHistoryViewModel
    {
        [Key]
        public long id { get; set; }
        public long headerId { get; set; }
        public long statusId { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public List<long> dataitems { get; set; }

        public string statusName { get; set; }
    }
}
