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
    public class TournamentService<T> : ITournamentService<T> where T : Tournament
    {
        private readonly ITournamentRepository<T> _tournamentRepository;
        private readonly IKnockoutLogic _knockoutLogic;

        public TournamentService(ITournamentRepository<T> tournamentRepository, IKnockoutLogic knockoutLogic)
        {
            _tournamentRepository = tournamentRepository;
            _knockoutLogic = knockoutLogic;
        }

        public void StartTournament(int tournamentId)
        {
            // 1️⃣ Adatok lekérése a Repository rétegből
            var tournament = _tournamentRepository.Read(tournamentId);
            if (tournament == null) throw new Exception("Tournament not found");

            // 2️⃣ Logika futtatása
            _knockoutLogic.ExecuteKnockout(tournament);

            // 3️⃣ Adatok mentése
            _tournamentRepository.Update(tournament);
        }
    }
}
