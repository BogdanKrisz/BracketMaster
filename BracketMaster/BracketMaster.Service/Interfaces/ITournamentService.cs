namespace BracketMaster.Service
{
    public interface ITournamentService<T>
    {
        void StartTournament(int tournamentId);
        void StartPreliminary(int tournamentId);
        void AddPlayer(int tournamentId, int playerId);
    }
}