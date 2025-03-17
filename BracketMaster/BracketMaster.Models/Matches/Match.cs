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
        public virtual Tournament? Tournament { get; set; }
        public required int TournamentId { get; set; } = 0;

        // number of round 
        public required int Round { get; set; } = 0;

        [NotMapped]
        public virtual Player? Home { get; set; }
        public required int HomeId { get; set; } = 0;

        [NotMapped]
        public virtual Player? Away { get; set; }
        public required int AwayId { get; set; } = 0;

        public int HomeScore { get; set; } = 0;
        public int AwayScore { get; set; } = 0;

        public virtual bool IsFinished { get; }

        [NotMapped]
        public virtual Player? Winner { get; set; }
        public int? WinnerId { get; set; }

        [NotMapped]
        public virtual Group? Group { get; set; }
        public int? GroupId { get; set; }

        protected Match() { }

        protected Match(int homeId, int awayId)
        {
            HomeId = homeId;
            AwayId = awayId;
        }

        public virtual void SetResult(int homeScore, int awayScore)
        {
            this.HomeScore = homeScore;
            this.AwayScore = awayScore;
            this.WinnerId = homeScore > awayScore ? HomeId : AwayId;
        }
    }
}
