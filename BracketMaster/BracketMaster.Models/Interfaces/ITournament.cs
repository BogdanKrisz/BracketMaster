
namespace BracketMaster.Models
{
    public interface ITournament : IEntity<int>
    {
        string Name { get; set; }

        ICollection<Match> Matches { get; set; } 
        ICollection<Player> Players { get; set; }
        ICollection<Player> Ranking { get; }

        int PointsForLose { get; set; }
        int PointsForWin { get; set; }

        PrelimineryType PrelimineryType { get; set; }
        KnockoutType KnockoutType { get; set; }
    }
}