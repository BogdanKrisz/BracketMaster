using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    [Table("Matches_Beerpong")]
    public class BeerpongMatch : Match, IBeerpongMatch
    {
        public override bool IsFinished { get { return HomeScore >= 10 || AwayScore >= 10; } }
        public bool IsOverTime { get { return HomeScore >= 10 && AwayScore >= 10; } }

        public int CupDifference { get { return Math.Abs(HomeScore - AwayScore); } }

        public BeerpongMatch(int tournamentId, int homeId, int awayId, int round) : base(tournamentId, homeId, awayId, round)
        {
        }

    }
}
