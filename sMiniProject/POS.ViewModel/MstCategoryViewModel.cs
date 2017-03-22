﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class MstCategoryViewModel
    {
        [Key]
        public long id { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string name { get; set; }
        [Display(Name = "Nama Kategori")]
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public bool active { get; set; }
    }
}
