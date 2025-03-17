using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public abstract class Tournament : Entity, ITournament
    {
        public string Name { get; set; }

        [NotMapped]
        public virtual Owner? Owner { get; set; }
        public int? OwnerId { get; set; }

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
        public virtual ICollection<Group> Groups { get; set; }

        [NotMapped]
        public virtual KnockoutSystem KnockoutSystem { get; set; }
        public int KnockoutSystemId { get; set; }

        // How many players advance to KO
        public int PlayersToAdvance { get; set; }

        // True -> Best X goes through from every group (depends on PlayersToAdvance)
        // False -> Ranking every player and the best players goes true (depends on the PlayersToAdvance)
        public bool GroupAdvancement { get; set; }

        public int PointsForWin { get; set; }
        public int PointsForLose { get; set; }

        public Tournament()
        {
            Players = new HashSet<Player>();
            Matches = new HashSet<Match>();
            Groups = new HashSet<Group>();
        }

    }
}
