using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BreakDown_Assistance.Models
{
    public class PurchaseDetail
    {
        [Key]
        [Required]
        [Column(nameof(PurchaseDetailID), TypeName = "int")]
        public int PurchaseDetailID { get; set; }

        [Required]
        [Column(nameof(PurchaseProductID), TypeName = "int")]
        public int PurchaseProductID { get; set; }
        [Required]
        [Column(nameof(PurchaseID), TypeName = "int")]
        public int PurchaseID { get; set; }
        [Required]
        [Column(nameof(Quantity), TypeName = "int")]
        public int Quantity { get; set; }
        [Required]
        [Column(nameof(Price), TypeName = "int")]
        public int Price { get; set; }
        [Required]
        [Column(nameof(Date), TypeName = "datetime")]
        public DateTime Date { get; set; }
        public Purchase purchase { get; set; }
        public PurchaseProduct purchaseProduct { get; set; }
    }
}
