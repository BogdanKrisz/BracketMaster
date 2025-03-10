using BracketMaster.Models;
using BracketMaster.Service.Interfaces;

namespace BracketMaster.Service
{
    public interface IMatchService<T> : IBasicService<T> where T : Match
    {
        void SetResult(int round, int homeId, int awayId, int homeScore, int awayScore);
        void SetResult(int matchId, int homeScore, int awayScore);
    }
}