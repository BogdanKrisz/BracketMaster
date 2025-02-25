using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public interface ITournamentLogic<T> : IBaseLogic<T> where T : Tournament
    {
        void StartNextRound();
        void StartElimination();
    }
}
