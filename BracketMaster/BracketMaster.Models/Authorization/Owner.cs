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
    [Table("Owners")]
    public class Owner : Entity, IOwner
    {
        public required string Username { get; set; } = string.Empty;

        [JsonIgnore]
        public required string PasswordHashed { get; set; } = string.Empty;

        [JsonIgnore]
        public required string PasswordSalt { get; set; } = string.Empty;

        [JsonIgnore]
        public required int PasswordIterationCount { get; set; } = 0;

        public required string Email { get; set; } = string.Empty;

        [JsonIgnore]
        public int? RefreshTokenId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual RefreshToken? RefreshToken { get; set; }

        [NotMapped]
        public ICollection<Tournament> Tournaments { get; set; }

        public Owner()
        {
            Tournaments = new HashSet<Tournament>();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
                return false;

            Owner otherOwner = obj as Owner;
            Owner thisOwner = this;
            return otherOwner.Id == thisOwner.Id &&
                otherOwner.Username == thisOwner.Username &&
                otherOwner.Email == thisOwner.Email;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Username, Email);
        }
    }
}
