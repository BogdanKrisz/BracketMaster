using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public class PreliminarySystem : Entity
    {
        public required string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
