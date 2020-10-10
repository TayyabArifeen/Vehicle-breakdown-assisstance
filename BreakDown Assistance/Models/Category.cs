using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BreakDown_Assistance.Models
{
    public class Category
    {

        [Key]
        [Required]
        [Column(nameof(CategoryID), TypeName = "int")]
        public int CategoryID { get; set; }
        [Required]
        [Column(nameof(CategoryTitle), TypeName = "nvarchar(100)")]
        public string CategoryTitle { get; set; }
        public List<Product> products { get; set; }
    }
}
