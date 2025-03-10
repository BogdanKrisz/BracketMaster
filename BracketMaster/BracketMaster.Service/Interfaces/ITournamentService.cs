using BracketMaster.Models;
using BracketMaster.Service.Interfaces;

namespace BracketMaster.Service
{
    public interface ITournamentService<T, P, G, M> : IBasicService<T> 
        where T : Tournament
        where P : Player
        where G : Group
        where M : Match
    {
        void AddPlayerToTournament(int tournamentId, int playerId);
        void RemovePlayerFromTournament(int playerId);
        void RemovePlayerFromTournament(int tournamentId, string playerName);

        void DeleteMatch(int matchId);
        void DeleteMatch(int tournamentId, int roundNumber, int homeId, int awayId);

        int GetGroupId(int tournamentId, string groupName);
        void AddPlayerToGroup(int groupId, int playerId);
        void RemovePlayerFromGroup(int groupId, int playerId);

        int GetMatchId(int tournamentId, int homePlayerId, int awayPlayerId, int round);
        void AddMatchToTournament(int tournamentId, int matchId);
        void CreateGroup(G group);
        void CreateMatch(M match);

        void StartTournament(int tournamentId);
        void StartKnockout(int tournamentId);
    }
}