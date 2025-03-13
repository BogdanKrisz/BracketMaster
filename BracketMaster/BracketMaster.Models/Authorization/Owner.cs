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
        [Required]
        [StringLength(256)]
        [Column("username")]
        public string Username { get; set; }

        [JsonIgnore]
        [StringLength(44)]
        [Column("hashed_password")]
        public string HashedPassword { get; set; }

        [JsonIgnore]
        [StringLength(24)]
        [Column("password_salt")]
        public string PasswordSalt { get; set; }

        [JsonIgnore]
        [StringLength(10)]
        [Column("iteration_count")]
        public string IterationCount { get; set; }

        [Required]
        [StringLength(256)]
        [Column("email")]
        public string Email { get; set; }

        [JsonIgnore]
        [Column("refresh_token_id")]
        public int? RefreshTokenId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual RefreshToken? RefreshToken { get; set; }

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
