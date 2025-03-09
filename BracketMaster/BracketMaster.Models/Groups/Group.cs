using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public abstract class Group : Entity, IGroup
    {
        public string Name { get; set; }

        [NotMapped]
        public virtual Tournament? Tournament { get; set; }
        public int? TournamentId { get; set; }

        [NotMapped]
        public virtual ICollection<Player> Players { get; set; }

        protected Group()
        {
            Players = new HashSet<Player>();
        }
    }
}
