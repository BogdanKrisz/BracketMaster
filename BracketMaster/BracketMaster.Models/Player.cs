using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public class Player : Entity
    {
        public string Name { get; set; }

        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }
    }
}
