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
    public class MatchService<M, P, G> : IMatchService<M, P, G> 
        where M : Match
        where P : Player
        where G : Group
    {
        readonly IMatchRepository<M> _matchRepository;
        readonly IMatchLogic<M, P> _matchLogic;

        readonly IPlayerService<P> _playerService;

        public MatchService(IMatchRepository<M> matchRepository, IMatchLogic<M, P> matchLogic, IPlayerService<P> playerService)
        {
            _matchRepository = matchRepository;
            _matchLogic = matchLogic;
            _playerService = playerService;
        }


        public void SetResult(int round, int homeId, int awayId, int homeScore, int awayScore)
        {
            var match = _matchRepository
                            .ReadAll()
                            .FirstOrDefault(m => m.Round == round && m.HomeId == homeId && m.AwayId == awayId);

            if (match == null) throw new Exception("Match not found");

            SetResult(match.Id, homeScore, awayScore);
        }

        // Módosításnál és törlésnél is kell majd átszámolni valahogy
        // Lehet hogy egyébként 0ról fogom mindig kiszámoltatni az összes meccs alapján, bár ez költséges úgyh lehet mégsem
        // átírhatnám linq-ra, mert lazy loadingból átszedni a dolgokat lassú lesz overtime
        public void SetResult(int matchId, int homeScore, int awayScore)
        {
            var match = _matchRepository.Read(matchId);
            if (match == null) throw new Exception("Match not found");

            match.SetResult(homeScore, awayScore);
            _matchRepository.Update(match);

            var homePlayer = match.Home as P;
            var awayPlayer = match.Away as P;

            var homePlayerResult = _matchLogic.AddPointsToPlayer(match, homePlayer);
            var awayPlayerResult = _matchLogic.AddPointsToPlayer(match, awayPlayer);

            _playerService.Update(homePlayerResult);
            _playerService.Update(awayPlayerResult);
        }

        public void Create(M item)
        {
            try
            {
                // megkéne nézni, valszeg a validate-ben, hogy a playernek a tournamentje és a matchnek a tournamentje megegyezik e
                _matchLogic.Validate(item);
                _matchRepository.Create(item);
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
                _matchRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public M Read(int id)
        {
            try
            {
                return _matchRepository.Read(id);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<M> ReadAll()
        {
            try
            {
                return _matchRepository.ReadAll();
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void Update(M item)
        {
            try
            {
                _matchLogic.Validate(item);
                _matchRepository.Update(item);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }
    }
}
