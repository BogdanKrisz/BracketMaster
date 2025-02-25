using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public abstract class KnockoutSystem : IKnockoutSystem
    {
        public ICollection<Player> Players { get; set; }
        public ICollection<Match> Matches { get; set; }
    }
}
