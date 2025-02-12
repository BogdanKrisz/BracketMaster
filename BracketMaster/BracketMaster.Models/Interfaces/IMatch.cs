namespace BracketMaster.Models
{
    public interface IMatch : IEntity<int>
    {
        Tournament Tournament { get; set; }
        int TournamentId { get; set; }

        int Round { get; set; }

        Player Home { get; set; }
        int HomeId { get; set; }

        Player Away { get; set; }
        int AwayId { get; set; }

        int HomeScore { get; set; }
        int AwayScore { get; set; }

        bool IsFinished { get; }

        Player Winner { get; }
        int WinnerId { get; set; }
    }
}