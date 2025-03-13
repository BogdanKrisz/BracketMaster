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
        [Required]
        [StringLength(250)]
        public string Token { get; set; }

        [Required]
        public DateTime Expiration { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int OwnerId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Owner Owner { get; set; }
    }
}
