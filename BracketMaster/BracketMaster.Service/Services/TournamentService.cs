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
        readonly ITournamentRepository<T> _tournamentRepository;
        readonly IKnockoutLogic _knockoutLogic;
        readonly IPreliminaryLogic _preliminaryLogic;

        public TournamentService(ITournamentRepository<T> tournamentRepository, IKnockoutLogic knockoutLogic, IPreliminaryLogic preliminaryLogic)
        {
            _tournamentRepository = tournamentRepository;
            _knockoutLogic = knockoutLogic;
            _preliminaryLogic = preliminaryLogic;
        }

        public void StartTournament(int tournamentId)
        {
            // 1️⃣ Adatok lekérése a Repository rétegből
            var tournament = _tournamentRepository.Read(tournamentId);
            if (tournament == null) throw new Exception("Tournament not found");

            // 2️⃣ Logika futtatása
            _knockoutLogic.ExecuteKnockout(tournament);
        }

        public void StartPreliminary(int tournamentId)
        {
            // 1️⃣ Adatok lekérése a Repository rétegből
            var tournament = _tournamentRepository.Read(tournamentId);
            if (tournament == null) throw new Exception("Tournament not found");

            // 2️⃣ Logika futtatása
            _preliminaryLogic.ExecutePreliminary(tournament);
        }

        // Ide kéne az add player a tournamentre sztem
        public void AddPlayer(int tournamentId, int playerId)
        {
            var tournament = _tournamentRepository.Read(tournamentId);
            if (tournament == null) throw new Exception("Tournament not found");

            // player ellenőrzés és addolás
        }
    }
}
