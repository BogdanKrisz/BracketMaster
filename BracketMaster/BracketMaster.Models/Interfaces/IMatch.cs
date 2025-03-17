namespace BracketMaster.Models
{
    public interface IMatch
    {
        int TournamentId { get; set; }
        Tournament? Tournament { get; set; }

        int Round { get; set; }

        int HomeId { get; set; }
        Player? Home { get; set; }

        int AwayId { get; set; }
        Player? Away { get; set; }

        int HomeScore { get; set; }
        int AwayScore { get; set; }

        bool IsFinished { get; }

        int? WinnerId { get; set; }
        Player? Winner { get; }
        
        void SetResult(int homeScore, int awayScore);
    }
}