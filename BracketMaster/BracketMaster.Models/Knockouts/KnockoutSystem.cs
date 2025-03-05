using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BracketMaster.Models
{
    [Table("KnockoutSystems")]
    public class KnockoutSystem : Entity
    {
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
