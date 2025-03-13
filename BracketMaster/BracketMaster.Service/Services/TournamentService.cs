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

        #region CRUD

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

        #endregion

        // logic rétegbe átszervezések
        // esetleg logicoknak egy közös interfész amelyben pl a validate-t kötelezővé tesszük

        // bajnokság logikák kialakítása

        // szerintem egy regisztráció kellene a készítőknek -> token rendszert áthozni?
        // jó lenne áthozni logger rendszert
        // catch részek megírása

        // jó lenne ha a játékosok is láthatnák a bajnokságot meg a rendszert, csak ne írhassanak bele nyilván (de ez frontend story lesz)

        #region NON-CRUD

        #region Tournament

        public int GetTournamentId(string name)
        {
            try
            {
                // Plussz itt az ownert is kéne nézni
                var tournament = _tournamentRepository.ReadAll().FirstOrDefault(t => t.Name == name);
                if (tournament == null) throw new Exception("Tournament not found");

                return tournament.Id;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

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
        #endregion

        #region Group

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

        public void CreateGroup(G group)
        {
            try
            {
                _groupService.Create(group);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void UpdateGroup(G group)
        {
            try
            {
                _groupService.Update(group);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void DeleteGroup(int groupId)
        {
            try
            {
                _groupService.Delete(groupId);
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

        public void RemovePlayerFromGroup(int playerId)
        {
            try
            {
                var player = _playerService.Read(playerId);
                if (player == null) throw new Exception("Player not found");

                // EZT ÁT LOGICBA
                if (!player.GroupId.HasValue)
                    throw new Exception("Player isnt part of a group");

                player.GroupId = null;
                _playerService.Update(player);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Match

        public int GetMatchId(int tournamentId, int homePlayerId, int awayPlayerId, int round)
        {
            try
            {
                var tournament = _tournamentRepository.Read(tournamentId);
                if (tournament == null) throw new Exception("Tournament not found");

                var match = _matchService.ReadAll().FirstOrDefault(m => m.TournamentId == tournamentId && m.HomeId == homePlayerId && m.AwayId == awayPlayerId);
                if (match == null) throw new Exception("Match not found");

                return match.Id;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void CreateMatch(M match)
        {
            try
            {
                _matchService.Create(match);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void UpdateMatch(M match)
        {
            try
            {
                _matchService.Update(match);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void DeleteMatch(int matchId)
        {
            try
            {
                _matchService.Delete(matchId);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void SetMatchResult(int matchId, int homeScore, int awayScore)
        {
            try
            {
                _matchService.SetResult(matchId, homeScore, awayScore);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Player

        public int GetPlayerId(int tournamentId, string playerName)
        {
            try
            {
                var tournament = _tournamentRepository.Read(tournamentId);
                if (tournament == null) throw new Exception("Tournament not found");

                var player = _playerService.ReadAll().FirstOrDefault(p => p.TournamentId == tournamentId && p.Name == playerName);
                if (player == null) throw new Exception("Player not found in this tournament");

                return player.Id;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void UpdatePlayer(P player)
        {
            try
            {
                _playerService.Update(player);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #endregion
    }
}
