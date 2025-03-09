using BracketMaster.Models;
using BracketMaster.Service.Interfaces;

namespace BracketMaster.Service
{
    public interface ITournamentService<T, K> : IBasicService<T> 
        where T : Tournament
        where K : Player
    {
        void StartTournament(int tournamentId);
        void StartKnockout(int tournamentId);
        void AddPlayer(int tournamentId, int playerId);
    }
}