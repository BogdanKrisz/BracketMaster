using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    [Table("Beerpong_Tournaments")]
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

        public BeerpongTournament()
        {
            Players = new HashSet<Player>(new HashSet<BeerpongPlayer>());
            Matches = new HashSet<Match>(new HashSet<BeerpongMatch>());
            Groups = new HashSet<Group>(new HashSet<BeerpongGroup>());
        }
    }
}