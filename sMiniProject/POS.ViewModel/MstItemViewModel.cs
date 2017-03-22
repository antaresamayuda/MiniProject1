using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class MstItemViewModel
    {
        [Key]
        public long id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Category ID")]
        public Nullable<long> categoryId { get; set; }

        public Nullable<long> createdBy { get; set; }

        public Nullable<System.DateTime> createdOn { get; set; }

        public Nullable<long> modifiedBy { get; set; }

        public Nullable<System.DateTime> modifiedOn { get; set; }

        [Display(Name = "Active")]
        public Boolean active { get; set; }

        public List<DTVariant> DataVariant { get; set; }

        //field tarik nama variant

        public long idVariant { get; set; }
        public string namaVariant { get; set; }

        //field tarik stock
        public List<MstItemVariantViewModel> variant { get; set; }
        //public List<MstItemInventoryViewModel> inventory { get; set; }
        public long InStock { get; set; }
        public long countItem { get; set; }

        public long idVrs { get; set; }
        public string variantNames { get; set; }
        public double prices { get; set; }
        public string skus { get; set; }
        public long beginnings { get; set; }
        public long alertAtQtys { get; set; }

        
    }

    public class DTVariant
    {
        public long idVr { get; set; }
        public string variantName { get; set; }
        public double price { get; set; }
        public string sku { get; set; }
        public long beginning { get; set; }
        public long alertAtQty { get; set; }
    }


        

    }

