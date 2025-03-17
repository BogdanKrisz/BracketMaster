using System.Text.RegularExpressions;

namespace BracketMaster.Models
{
    public interface IPlayer : IComparable<Player>
    {
        string Name { get; set; }

        Tournament? Tournament { get; set; }
        int TournamentId { get; set; }

        Group? Group { get; set; }
        int? GroupId { get; set; }

        ICollection<Match>? HomeMatches { get; set; }
        ICollection<Match>? AwayMatches { get; set; }
        ICollection<Player>? PreviousOpponents { get; }

        int Points { get; }
    }
}