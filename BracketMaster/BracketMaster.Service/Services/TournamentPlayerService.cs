using BracketMaster.Logic;
using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Service
{
    public class TournamentPlayerService<T> : ITournamentPlayerService<T> where T : TournamentPlayer
    {
        readonly ITournamentPlayerRepository<T> _tournamentPlayerRepository;
        readonly ITournamentPlayerLogic<T> _tournamentPlayerLogic;

        public TournamentPlayerService(ITournamentPlayerRepository<T> tournamentPlayerRepository, ITournamentPlayerLogic<T> tournamentPlayerLogic)
        {
            _tournamentPlayerRepository = tournamentPlayerRepository;
            _tournamentPlayerLogic = tournamentPlayerLogic;
        }
    }
}
