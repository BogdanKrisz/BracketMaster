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
        // Tournament
        int GetTournamentId(string name);

        void AddPlayerToTournament(int tournamentId, int playerId);
        void RemovePlayerFromTournament(int playerId);

        void AddMatchToTournament(int tournamentId, int matchId);

        void StartTournament(int tournamentId);
        void StartKnockout(int tournamentId);

        // Group
        int GetGroupId(int tournamentId, string groupName);

        void CreateGroup(G group); // G -be tesszük a bajnokság id-ját
        void UpdateGroup(G group);
        void DeleteGroup(int groupId);

        void AddPlayerToGroup(int groupId, int playerId);
        void RemovePlayerFromGroup(int playerId);

        // Match
        int GetMatchId(int tournamentId, int homePlayerId, int awayPlayerId, int round);

        void SetMatchResult(int matchId, int homeScore, int awayScore);
        void CreateMatch(M match); // M -be tesszük a bajnokság id-ját, és a csoport Id-ját
        void UpdateMatch(M match);
        void DeleteMatch(int matchId);

        // Player
        int GetPlayerId(int tournamentId, string playerName);
        void UpdatePlayer(P player);
    }
}