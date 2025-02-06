using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public class Match
    {
        public int Id { get; set; }
        public Tournament Tournament { get; set; }

        public Player Home { get; set; }
        public Player Away { get; set; }

        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public bool IsFinished { get { return HomeScore >= 10 || AwayScore >= 10; } }
        public bool IsOverTime { get { return HomeScore >= 10 && AwayScore >= 10; } }

        public Player Winner { get { return HomeScore > AwayScore ? Home : Away; } }
        public int CupDifference { get { return Math.Abs(HomeScore - AwayScore); } }
    }
}
