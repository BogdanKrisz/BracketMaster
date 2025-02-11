using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public class Player : Entity
    {
        public string Name { get; set; }

        [NotMapped]
        public virtual Tournament Tournament { get; set; }
        public int TournamentId { get; set; }

        [NotMapped]
        public virtual ICollection<Match> HomeMatches { get; set; }

        [NotMapped]
        public virtual ICollection<Match> AwayMatches { get; set; }

        public Player()
        {
            HomeMatches = new HashSet<Match>();
            AwayMatches = new HashSet<Match>();
        }
    }
}
