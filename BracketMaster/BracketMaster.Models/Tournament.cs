using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public class Tournament : Entity
    {
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Player> Players { get; set; }

        [NotMapped]
        public virtual ICollection<Match> Matches { get; set; }

        public Tournament()
        {
            Players = new HashSet<Player>();
            Matches = new HashSet<Match>();
        }
    }
}
