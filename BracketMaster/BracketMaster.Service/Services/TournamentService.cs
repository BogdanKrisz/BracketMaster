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
    public class TournamentService<T, K> : ITournamentService<T, K> 
        where T : Tournament 
        where K : Player
    {
        readonly ITournamentRepository<T> _tournamentRepository;
        readonly ITournamentLogic<T> _tournamentLogic;

        readonly IPlayerService<K> _playerService;

        readonly KnockoutHandlerFactory _knockoutHandlerFactory;
        readonly PreliminaryHandlerFactory _preliminaryHandlerFactory;

        public TournamentService(ITournamentRepository<T> tournamentRepository, ITournamentLogic<T> tournamentLogic, IPlayerService<K> playerService, KnockoutHandlerFactory knockoutHandlerFactory, PreliminaryHandlerFactory preliminaryHandlerFactory)
        {
            _tournamentRepository = tournamentRepository;
            _tournamentLogic = tournamentLogic;
            _playerService = playerService;
            _knockoutHandlerFactory = knockoutHandlerFactory;
            _preliminaryHandlerFactory = preliminaryHandlerFactory;
        }

        public void StartTournament(int tournamentId)
        {
            // kellene preliminaryService
            // kellene knockoutService
            // itt a start tournamentből a preliminaryServicebe át -> és indítani az új köröket (előre megkéne határozni a körök számát, ha 0 akkor meg manuálisan kövi kör indítás)


            // fontos lenne!!! -> Groups preliminarynál választási lehetőség
            // előre meghatározott (A1 vs D2 ...) vagy rangsor ott is 
            try
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
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void StartKnockout(int tournamentId)
        {
            try
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
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void AddPlayer(int tournamentId, int playerId)
        {
            try
            {
                var tournament = _tournamentRepository.Read(tournamentId);
                if (tournament == null) throw new Exception("Tournament not found");

                // player ellenőrzés és addolás
                var player = _playerService.Read(playerId);
                if (player == null) throw new Exception("Player not found");

                player.TournamentId = tournamentId;
                _playerService.Update(player);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void Create(T item)
        {
            try
            {
                _tournamentLogic.Validate(item);
                _tournamentRepository.Create(item);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public T Read(int id)
        {
            try
            {
                return _tournamentRepository.Read(id);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<T> ReadAll()
        {
            try
            {
                return _tournamentRepository.ReadAll();
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void Update(T item)
        {
            try
            {
                _tournamentLogic.Validate(item);
                _tournamentRepository.Update(item);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(int id)
        {
            try
            {
                _tournamentRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            } 
        }
    }
}
