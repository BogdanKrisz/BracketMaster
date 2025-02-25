using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    [Table("Tournaments_Beerpong")]
    public class BeerpongTournament : Tournament, IBeerpongTournament
    {
        public int PointsForOverTimeWin { get; set; }
        public int PointsForOverTimeLose { get; set; }

        public override ICollection<Player> Ranking
        {
            get 
            {
                List<BeerpongPlayer> bpongResult = Players.OfType<BeerpongPlayer>().ToList();
                bpongResult.Sort();
                return bpongResult.Cast<Player>().ToList();
            }
        }


        public BeerpongTournament() : base()
        {
            
        }

        public BeerpongTournament(string name, int preliminaryId, int knockoutId, int playersToElimination) 
            : base(name, preliminaryId, knockoutId, playersToElimination)
        {
            Players = new HashSet<Player>(new HashSet<BeerpongPlayer>());
            Matches = new HashSet<Match>(new HashSet<BeerpongMatch>());
        }
    }
}