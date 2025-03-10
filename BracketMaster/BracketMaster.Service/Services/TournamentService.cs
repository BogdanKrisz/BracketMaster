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
    public class TournamentService<T, P, G, M> : ITournamentService<T, P, G, M> 
        where T : Tournament 
        where P : Player
        where G : Group
        where M : Match
    {
        readonly ITournamentRepository<T> _tournamentRepository;
        readonly ITournamentLogic<T> _tournamentLogic;

        readonly IPlayerService<P, G, M> _playerService;
        readonly IGroupService<G> _groupService;
        readonly IMatchService<M> _matchService;

        readonly KnockoutHandlerFactory _knockoutHandlerFactory;
        readonly PreliminaryHandlerFactory _preliminaryHandlerFactory;

        public TournamentService(
            ITournamentRepository<T> tournamentRepository, 
            ITournamentLogic<T> tournamentLogic, 
            IPlayerService<P, G, M> playerService, 
            IGroupService<G> groupService, 
            IMatchService<M> matchService, 
            KnockoutHandlerFactory knockoutHandlerFactory, 
            PreliminaryHandlerFactory preliminaryHandlerFactory)
        {
            _tournamentRepository = tournamentRepository;
            _tournamentLogic = tournamentLogic;
            _playerService = playerService;
            _groupService = groupService;
            _matchService = matchService;
            _knockoutHandlerFactory = knockoutHandlerFactory;
            _preliminaryHandlerFactory = preliminaryHandlerFactory;
        }

        // Player tournamenthez adása
        // Group tournamenthez adása (ha van group) (bajnokság indításakor elég meghívni )
        // Player Grouphoz adása
        // Match tournamenthez adása + Match Grouphoz adása (ha van group)
        // játékosok elosztása csoportokba (ha van group)
        // csoport generálása és tournamenthez adása



        // -- Grouppoknál meccsek kiírása
        // grouppoknál playerek kiírása

        public void AddPlayerToTournament(int tournamentId, int playerId)
        {
            try
            {
                var tournament = _tournamentRepository.Read(tournamentId);
                if (tournament == null) throw new Exception("Tournament not found");

                // player ellenőrzés és addolás
                var player = _playerService.Read(playerId);
                if (player == null) throw new Exception("Player not found");

                // logicból egy már létezik ilyen player a bajeszban 

                player.TournamentId = tournamentId;
                _playerService.Update(player);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void RemovePlayerFromTournament(int playerId)
        {
            try
            {
                _playerService.Delete(playerId);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void RemovePlayerFromTournament(int tournamentId, string playerName)
        {
            try
            {
                var tournament = _tournamentRepository.Read(tournamentId);
                if (tournament == null) throw new Exception("Tournament not found");

                var player = _playerService.ReadAll().FirstOrDefault(p => p.TournamentId == tournamentId && p.Name == playerName);
                if (player == null) throw new Exception("Player not found in this tournament");

                RemovePlayerFromTournament(player.Id);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }
        
        public int GetGroupId(int tournamentId, string groupName)
        {
            try
            {
                var tournament = _tournamentRepository.Read(tournamentId);
                if (tournament == null) throw new Exception("Tournament not found");

                var group = _groupService.ReadAll().FirstOrDefault(g => g.TournamentId == tournamentId && g.Name == groupName);
                if (group == null) throw new Exception("Group not found in this tournament");

                return group.Id;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void AddPlayerToGroup(int groupId, int playerId)
        {
            try
            {
                var group = _groupService.Read(groupId);
                if (group == null) throw new Exception("Group not found");

                var player = _playerService.Read(playerId);
                if (player == null) throw new Exception("Player not found");

                // EZT ÁT EGY LOGICBA
                if (player.GroupId.HasValue)
                    throw new Exception("This player is already in a group");

                player.GroupId = groupId;
                _playerService.Update(player);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void RemovePlayerFromGroup(int groupId, int playerId)
        {
            try
            {
                var group = _groupService.Read(groupId);
                if (group == null) throw new Exception("Group not found");

                var player = _playerService.Read(playerId);
                if (player == null) throw new Exception("Player not found");

                // EZT ÁT LOGICBA
                if (player.GroupId != groupId)
                    throw new Exception("Player isnt part of this group");

                player.GroupId = null;
                _playerService.Update(player);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public int GetMatchId(int tournamentId, int homePlayerId, int awayPlayerId, int round)
        {
            var tournament = _tournamentRepository.Read(tournamentId);
            if (tournament == null) throw new Exception("Tournament not found");

            var match = _matchService.ReadAll().FirstOrDefault(m => m.TournamentId == tournamentId && m.HomeId == homePlayerId && m.AwayId == awayPlayerId);
            if (match == null) throw new Exception("Match not found");

            return match.Id;
        }

        public void AddMatchToTournament(int tournamentId, int matchId)
        {
            try
            {
                var match = _matchService.Read(matchId);
                if (match == null) throw new Exception("Match not found");

                var tournament = _tournamentRepository.Read(tournamentId);
                if (tournament == null) throw new Exception("Tournament not found");

                // LOGICBA -> megkeresni meccs résztvevőket és abba a csoportba rakni őket
                if (tournament.Groups.Count > 0)
                {
                    var playerHome = match.Home;
                    match.GroupId = playerHome.GroupId;
                }

                match.TournamentId = tournamentId;
                _matchService.Update(match);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void DeleteMatch(int matchId)
        {
            _matchService.Delete(matchId);
        }

        public void DeleteMatch(int tournamentId, int roundNumber, int homeId, int awayId)
        {
            try
            {
                var tournament = _tournamentRepository.Read(tournamentId);
                if (tournament == null) throw new Exception("Tournament not found");

                var match = _matchService.ReadAll().FirstOrDefault(m => m.TournamentId == tournamentId && m.Round == roundNumber && m.HomeId == homeId && m.AwayId == awayId);
                if (match == null) throw new Exception("Match not found");

                DeleteMatch(match.Id);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }


        public void CreateGroup(G group)
        {
            _groupService.Create(group);
        }

        public void CreateMatch(M match)
        {
            _matchService.Create(match);
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
