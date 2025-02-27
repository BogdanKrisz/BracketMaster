using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public abstract class TournamentPlayer : Entity, ITournamentPlayer
    {
        [NotMapped]
        public virtual Player Player { get; set; }
        public int PlayerId { get; set; }

        [NotMapped]
        public virtual Tournament Tournament { get; set; }
        public int TournamentId { get; set; }
    }
}
