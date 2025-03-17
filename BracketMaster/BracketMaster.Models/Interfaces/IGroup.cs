namespace BracketMaster.Models
{
    public interface IGroup
    {
        string Name { get; set; }
        int MatchesPerPlayer { get; set; }
        Tournament? Tournament { get; set; }
        int TournamentId { get; set; }
    }
}