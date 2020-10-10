using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BreakDown_Assistance.Models
{
    public class Purchase
    {

        [Key]
        [Required]
        [Column(nameof(PurchaseID), TypeName = "int")]
        public int PurchaseID { get; set; }
        [Required]
        [Column(nameof(PurchaseTitle), TypeName = "nvarchar(100)")]
        public string PurchaseTitle { get; set; }
        [Required]
        [Column(nameof(Date), TypeName = "datetime")]
        public DateTime Date { get; set; }


        public int totalPrice = 0;
        [Required]
        [Column(nameof(TotalPrice), TypeName = "int")]
        public int TotalPrice
        {
            get
            {
                return this.totalPrice;

            }
            set
            {
                this.totalPrice = value;
            }
        }
        public List<PurchaseDetail> purchaseDetails { get; set; }
    }
}
