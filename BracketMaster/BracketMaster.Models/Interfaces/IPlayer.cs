using System.Text.RegularExpressions;

namespace BracketMaster.Models
{
    public interface IPlayer : IEntity<int>
    {
        string Name { get; set; }

        Tournament Tournament { get; set; }
        int TournamentId { get; set; }

        ICollection<Match> HomeMatches { get; set; }
        ICollection<Match> AwayMatches { get; set; }

        int Points { get; }

        int CompareTo(Player? other);
    }
}