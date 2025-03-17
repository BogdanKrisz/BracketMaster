
namespace BracketMaster.Models
{
    public interface ITournament
    {
        string Name { get; set; }
        int NumOfTables { get; set; }

        Owner? Owner { get; set; }
        int OwnerId { get; set; }

        ICollection<Match>? Matches { get; set; } 
        ICollection<Player>? Players { get; set; }
        ICollection<Player>? Ranking { get; }

        int PointsForLose { get; set; }
        int PointsForWin { get; set; }

        int PreliminarySystemId { get; set; }
        int KnockoutSystemId { get; set; }

        int? PlayersToAdvance { get; set; }
        bool? GroupAdvancement { get; set; }
    }
}