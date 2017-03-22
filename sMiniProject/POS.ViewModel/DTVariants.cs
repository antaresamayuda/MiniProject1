using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class DTVariants
    {
        public long idVr { get; set; }
        public string variantName { get; set; }
        public double price { get; set; }
        public string sku { get; set; }
        public long beginning { get; set; }
        public long alertAtQty { get; set; }
    }
}
