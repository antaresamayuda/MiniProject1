using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.ViewModel
{
    public class TrxPoHistoryViewModel
    {
        [Key]
        public long id { get; set; }
        public long headerId { get; set; }
        public long statusId { get; set; }
        public Nullable<long> createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
    }
}
