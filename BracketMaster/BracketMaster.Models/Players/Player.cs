using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public abstract class Player : Entity, IPlayer
    {
        public string Name { get; set; }

        [NotMapped]
        public virtual Tournament Tournament { get; set; }
        public int TournamentId { get; set; }

        [NotMapped]
        public virtual ICollection<Match> HomeMatches { get; set; }

        [NotMapped]
        public virtual ICollection<Match> AwayMatches { get; set; }

        [NotMapped]
        public abstract int Points { get; }

        [NotMapped]
        public ICollection<Player> PreviousOpponents 
        { 
            get 
            { 
                ICollection<Player> opponents = new List<Player>();
                foreach (Match match in HomeMatches)
                {
                    opponents.Add(match.Away);
                }
                foreach (Match match in AwayMatches)
                {
                    opponents.Add(match.Home);
                }
                return opponents;
            } 
        }

        public abstract int CompareTo(Player? other);

        protected Player(string name, int tournamentId)
        {
            Name = name;
            TournamentId = tournamentId;
        }
    }
}
