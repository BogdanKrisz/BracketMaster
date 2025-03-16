using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public class RegisterModel
    {
        public required string Username { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
    }
}
