using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public abstract class Match : Entity, IMatch
    {
        [NotMapped]
        public virtual Tournament Tournament { get; set; }
        public int TournamentId { get; set; }

        // number of round 
        public int Round { get; set; }

        [NotMapped]
        public virtual Player Home { get; set; }
        public int HomeId { get; set; }

        [NotMapped]
        public virtual Player Away { get; set; }
        public int AwayId { get; set; }

        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public virtual bool IsFinished { get; set; }

        [NotMapped]
        public virtual Group? Group { get; set; }
        public int? GroupId { get; set; }

        [NotMapped]
        public virtual Player Winner 
        {
            get 
            {
                if (!IsFinished)
                    return null;
                return HomeScore > AwayScore ? Home : Away;
            } 
        }

        public int WinnerId { get; set; }

        protected Match()
        {
            
        }

        public virtual void SetResult(int homeScore, int awayScore)
        {
            this.HomeScore = homeScore;
            this.AwayScore = awayScore;
            this.WinnerId = Winner.Id;
        }
    }
}
