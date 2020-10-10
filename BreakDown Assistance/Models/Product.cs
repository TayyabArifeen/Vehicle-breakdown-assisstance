using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BreakDown_Assistance.Models
{
    public class Product
    {

        [Key]
        [Required]
        [Column(nameof(ProductID), TypeName = "int")]
        public int ProductID { get; set; }
        [Required]
        [Column(nameof(CategoryID), TypeName = "int")]
        public int CategoryID { get; set; }
        [Required]
        [Column(nameof(Price), TypeName = "int")]
        public int Price { get; set; }
        [Required]
        [Column(nameof(ProductTitle), TypeName = "nvarchar(100)")]
        public string ProductTitle { get; set; }
        public Category Category { get; set; }
        public List<PurchaseProduct> purchaseProducts { get; set; }
    }
}
