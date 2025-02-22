using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
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

        public BeerpongTournament(string name, IPreliminarySystem preType, IKnockoutSystem knockoutType, int playersToElimination) 
            : base(name, preType, knockoutType, playersToElimination)
        {
            Players = new HashSet<Player>(new HashSet<BeerpongPlayer>());
            Matches = new HashSet<Match>(new HashSet<BeerpongMatch>());
        }
    }
}