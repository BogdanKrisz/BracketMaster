using BracketMaster.Models;
using BracketMaster.Service.Interfaces;

namespace BracketMaster.Service
{
    public interface IMatchService<M, P, G> : IBasicService<M>
        where M : Match
        where P : Player
        where G : Group
    {
        void SetResult(int round, int homeId, int awayId, int homeScore, int awayScore);
        void SetResult(int matchId, int homeScore, int awayScore);
    }
}