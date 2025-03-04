using BracketMaster.Models;
using BracketMaster.Service.Interfaces;

namespace BracketMaster.Service
{
    public interface ITournamentService<T> : IBasicService<T> where T : Tournament
    {
        void StartTournament(int tournamentId);
        void StartPreliminary(int tournamentId);
        void AddPlayer(int tournamentId, int playerId);
    }
}