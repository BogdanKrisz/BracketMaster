using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BracketMaster.Models
{
    public class KnockoutSystem : Entity
    {
        public required string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
