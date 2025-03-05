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
        readonly ITournamentLogic<T> _tournamentLogic;

        readonly KnockoutHandlerFactory _knockoutHandlerFactory;
        readonly PreliminaryHandlerFactory _preliminaryHandlerFactory;

        public TournamentService(ITournamentRepository<T> tournamentRepository, ITournamentLogic<T> tournamentLogic, KnockoutHandlerFactory knockoutHandlerFactory, PreliminaryHandlerFactory preliminaryHandlerFactory)
        {
            _tournamentRepository = tournamentRepository;
            _tournamentLogic = tournamentLogic;
            _knockoutHandlerFactory = knockoutHandlerFactory;
            _preliminaryHandlerFactory = preliminaryHandlerFactory;
        }

        public void StartTournament(int tournamentId)
        {
            // get tournament
            var tournament = _tournamentRepository.Read(tournamentId);
            if (tournament == null) throw new Exception("Tournament not found");

            // validate
            _tournamentLogic.Validate(tournament);

            // get knockout system
            var knockoutSystem = tournament.KnockoutSystem;
            if (knockoutSystem == null)
                throw new Exception("No knockout system assigned to this tournament!");

            // get logic for knockout system
            var knockoutLogic = _knockoutHandlerFactory.GetLogic(knockoutSystem);

            // execute knockout
            knockoutLogic.ExecuteKnockout(knockoutSystem, tournament);
        }

        public void StartKnockout(int tournamentId)
        {
            // get tournament
            var tournament = _tournamentRepository.Read(tournamentId);
            if (tournament == null) throw new Exception("Tournament not found");

            // validate
            _tournamentLogic.Validate(tournament);

            // get preliminary system
            var preliminarySystem = tournament.PreliminarySystem;
            if (preliminarySystem == null)
                throw new Exception("No preliminary system assigned to this tournament!");

            // get logic for preliminary system
            var preliminaryLogic = _preliminaryHandlerFactory.GetLogic(preliminarySystem);

            // execute preliminary
            preliminaryLogic.ExecutePreliminary(preliminarySystem, tournament);
        }

        // Ide kéne az add player a tournamentre sztem
        public void AddPlayer(int tournamentId, int playerId)
        {
            var tournament = _tournamentRepository.Read(tournamentId);
            if (tournament == null) throw new Exception("Tournament not found");

            // player ellenőrzés és addolás
        }

        public void Create(T item)
        {
            _tournamentLogic.Validate(item);
            _tournamentRepository.Create(item);
        }

        public T Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
