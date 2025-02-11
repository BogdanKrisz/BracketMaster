using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public class Match : Entity
    {
        [NotMapped]
        public virtual Tournament Tournament { get; set; }
        public int TournamentId { get; set; }
        
        public int Round { get; set; }

        [NotMapped]
        public virtual Player Home { get; set; }
        public int HomeId { get; set; }

        [NotMapped]
        public virtual Player Away { get; set; }
        public int AwayId { get; set; }

        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public bool IsFinished { get { return HomeScore >= 10 || AwayScore >= 10; } }
        public bool IsOverTime { get { return HomeScore >= 10 && AwayScore >= 10; } }

        [NotMapped]
        public virtual Player Winner { get { return HomeScore > AwayScore ? Home : Away; } }
        public int WinnerId { get; set; }

        public int CupDifference { get { return Math.Abs(HomeScore - AwayScore); } }
    }
}
