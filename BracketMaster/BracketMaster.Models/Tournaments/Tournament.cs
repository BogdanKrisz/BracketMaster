using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    [Table("Tournaments")]
    public abstract class Tournament : Entity, ITournament
    {
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Player> Players { get; set; }

        [NotMapped]
        public virtual ICollection<Match> Matches { get; set; }

        [NotMapped]
        public abstract ICollection<Player> Ranking { get; }

        public IPreliminarySystem PreliminaryType { get; set; }
        public IKnockoutSystem KnockoutType { get; set; }

        public int PlayersToElimination { get; set; }

        public int PointsForWin { get; set; }
        public int PointsForLose { get; set; }

        protected Tournament(string name, IPreliminarySystem preType, IKnockoutSystem knockoutType, int playersToElimination)
        {
            Name = name;
            PreliminaryType = preType;
            KnockoutType = knockoutType;
            PlayersToElimination = playersToElimination;
        }
    }
}
