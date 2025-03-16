using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    [Table("RefreshTokens")]
    public class RefreshToken : Entity, IRefreshToken
    {
        public required string Token { get; set; } = string.Empty;

        public required DateTime Expiration { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public int? OwnerId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Owner? Owner { get; set; }
    }
}
