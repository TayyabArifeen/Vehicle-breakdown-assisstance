using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BreakDown_Assistance.Models
{
    public class PurchaseProduct
    {
        [Key]
        [Required]
        [Column(nameof(PurchaseProductID), TypeName = "int")]
        public int PurchaseProductID { get; set; }
        [Required]
        [Column(nameof(ProductID), TypeName = "int")]
        public int ProductID { get; set; }
        public List<PurchaseDetail> purchaseDetails { get; set; }
        public Product products { get; set; }
    }
}
