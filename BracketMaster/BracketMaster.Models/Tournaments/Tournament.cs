using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public enum PrelimineryType { RoundRobin, Swiss, Random }
    public enum KnockoutType { Single, Double, Triple, None }

    public abstract class Tournament : Entity, ITournament
    {
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Player> Players { get; set; }

        [NotMapped]
        public virtual ICollection<Match> Matches { get; set; }

        public PrelimineryType PrelimineryType { get; set; }

        public KnockoutType KnockoutType { get; set; }

        public int PointsForWin { get; set; }
        public int PointsForLose { get; set; }

        protected Tournament()
        {
            Players = new HashSet<Player>();
            Matches = new HashSet<Match>();
        }
    }
}
