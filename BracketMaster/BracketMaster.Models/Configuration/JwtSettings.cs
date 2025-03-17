using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public class JwtSettings
    {
        public required string Key { get; set; } = string.Empty;
        public required string Issuer { get; set; } = string.Empty;
        public required string Audience { get; set; } = string.Empty;
        public required int ExpiryMinutes { get; set; } = 0;
    }
}
