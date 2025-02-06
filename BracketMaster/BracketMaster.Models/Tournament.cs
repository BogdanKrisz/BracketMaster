using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public class Tournament : Entity
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public List<Match> Matches { get; set; }

        public Tournament()
        {
            Players = new List<Player>();
            Matches = new List<Match>();
        }
    }
}
