using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public class RefreshTokenRequest
    {
        public required string Token { get; set; } = string.Empty;
        public required string RefreshToken { get; set; } = string.Empty;
    }
}
