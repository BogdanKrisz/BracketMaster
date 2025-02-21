using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public abstract class Tournament : Entity, ITournament
    {
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Player> Players { get; set; }

        [NotMapped]
        public virtual ICollection<Match> Matches { get; set; }

        [NotMapped]
        public abstract ICollection<Player> Ranking { get; }

        public IPreliminarySystem PrelimineryType { get; set; }
        public IKnockoutSystem KnockoutType { get; set; }

        public int PlayersToElimination { get; set; }

        public int PointsForWin { get; set; }
        public int PointsForLose { get; set; }

        protected Tournament(string name, IPreliminarySystem preType, IKnockoutSystem knockoutType, int playersToElimination)
        {
            Name = name;
            PrelimineryType = preType;
            KnockoutType = knockoutType;
            PlayersToElimination = playersToElimination;
        }

        // Nem biztos még hogy ide kell kerüljenek az alábbi metódusok
        public virtual void AddPlayer(Player player)
        {
            //
        }

        public virtual void RemovePlayer(int playerId)
        {
            //
        }

        public virtual void GenerateMatches()
        {
            //
        }

        public virtual void StartTournament()
        {
            //
        }

        public virtual void StartElimination()
        {
            //
        }
    }
}
