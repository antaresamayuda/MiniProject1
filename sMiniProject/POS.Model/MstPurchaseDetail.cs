﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    [Table("pos_t_purchase_detail")]
    public class MstPurchaseDetail
    {
        [Key]
        public long id { get; set; }
        public long headerId { get; set; }
        public long variantId { get; set; }
        public long requestQty { get; set; }
        public Nullable<double> unitCost { get; set; }
        public Nullable<double> subTotal { get; set; }

        public Nullable<long> createdBy { get; set; }
        public Nullable<System.DateTime> createdOn { get; set; }
        public Nullable<long> modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedOn { get; set; }

    }
}
