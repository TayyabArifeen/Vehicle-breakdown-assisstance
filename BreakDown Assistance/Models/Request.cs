using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BreakDown_Assistance.Models
{
    [Table("Request")]
    public class Request
    {
        [Key]
        [Required]
        [Column(nameof(id), TypeName = "int")]
        public int id { get; set; }

        [Required]
        [Column(nameof(mechanic_ID), TypeName = "int")]
        public int mechanic_ID { get; set; }

        [Required]
        [Column(nameof(vehcileType), TypeName = "nvarchar(50)")]
        public string vehcileType { get; set; }
        [Required]
        [Column(nameof(longitude), TypeName = "float")]
        public float longitude { get; set; }
        [Required]
        [Column(nameof(latitude), TypeName = "float")]
        public float latitude { get; set; }
        public Mechanics mehanics { get; set; }
    }
}
