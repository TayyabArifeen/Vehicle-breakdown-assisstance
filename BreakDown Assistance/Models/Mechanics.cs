using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BreakDown_Assistance.Models
{
    [Table("Mechanics")]
    public class Mechanics
    {
        [Key]
        [Required]
        [Column(nameof(id),TypeName="int")]
        public int id { get; set; }
        [Required]
        [Column(nameof(name), TypeName = "nvarchar(50)")]
        public string name { get; set; }
        [Required]
        [Column(nameof(contact_Number), TypeName = "int")]
        public int contact_Number { get; set; }
        [Required]
        [Column(nameof(availability), TypeName = "nvarchar(50)")]
        public string availability { get; set; }
        [Required]
        [Column(nameof(location), TypeName = "float")]
        public float location { get; set; }

    }
}
