using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models.Tournament_Player
{
    [Table("TournamentPlayer_Beerpong")]
    public class BeerpongTournament_BeerpongPlayer : Entity, ITournamentPlayer
    {
        [NotMapped]
        public virtual BeerpongPlayer Player { get; set; }
        public int PlayerId { get; set; }

        [NotMapped]
        public virtual BeerpongTournament Tournament { get; set; }
        public int TournamentId { get; set; }
    }
}
