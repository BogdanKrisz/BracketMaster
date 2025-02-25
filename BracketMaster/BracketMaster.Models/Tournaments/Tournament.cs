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

        [NotMapped]
        public virtual PreliminarySystem PreliminarySystem { get; set; }
        public int PreliminarySystemId { get; set; }
 
        [NotMapped]
        public virtual KnockoutSystem KnockoutSystem { get; set; }
        public int KnockoutSystemId { get; set; }

        public int PlayersToElimination { get; set; }

        public int PointsForWin { get; set; }
        public int PointsForLose { get; set; }

        protected Tournament()
        {
            
        }

        protected Tournament(string name, int preliminaryId, int knockoutId, int playersToElimination)
        {
            Name = name;
            PreliminarySystemId = preliminaryId;
            KnockoutSystemId = knockoutId;
            PlayersToElimination = playersToElimination;
        }
    }
}
