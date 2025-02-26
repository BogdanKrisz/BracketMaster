using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
