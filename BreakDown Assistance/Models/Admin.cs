using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BreakDown_Assistance.Models
{
    public class Admin
    {
        [Key]
        [Required]
        [Column(nameof(AdminID), TypeName = "int")]
        public int AdminID { get; set; }
        [Required]
        [Column(nameof(Name), TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Required]
        [Column(nameof(Email), TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        [Required]
        [Column(nameof(Password), TypeName = "nvarchar(100)")]
        public string Password { get; set; }
    }
}
