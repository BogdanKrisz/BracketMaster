using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    // lehetne implementálni egy Tournament Statust, pl Not started, In progress, finished. Vagy pl a progressen belül is, hogy hanyadik kör, aztán hogy pl már KO aztán finished

    public abstract class TournamentLogic<T> : ITournamentLogic<T> where T : Tournament
    {
        protected TournamentLogic()
        {
 
        }

        public virtual void Validate(T item)
        {
            if (item == null) throw new ArgumentNullException($"Tournament is null!");
            if (item.Name.Length < 3) throw new ArgumentException($"'{item.Name}' for tournament name is too short!");
            if (item.KnockoutSystemId < 0) throw new ArgumentNullException("Knockout type is invalid!");
            if (item.PreliminarySystemId < 0) throw new ArgumentNullException("Preliminary type is invalid!");
            if (item.PointsForWin <= 0) throw new ArgumentException("Points for win can't be lower than 1!");
            if (item.PointsForLose >= item.PointsForWin) throw new ArgumentException("Points for lose has to be lower than points for win!");
        }
    }
}
