using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public class BeerpongOvertimeType : Entity
    {
        public required string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
