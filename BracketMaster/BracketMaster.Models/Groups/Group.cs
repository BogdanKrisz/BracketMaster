using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public abstract class Group : Entity, IGroup
    {
        public required string Name { get; set; } = string.Empty;

        public required int TournamentId { get; set; } = 0;

        [NotMapped]
        public virtual Tournament? Tournament { get; set; }

        [NotMapped]
        public virtual ICollection<Player> Players { get; set; }
        [NotMapped]
        public virtual ICollection<Match> Matches { get; set; }

        protected Group()
        {
            Players = new HashSet<Player>();
            Matches = new HashSet<Match>();
        }
    }
}
