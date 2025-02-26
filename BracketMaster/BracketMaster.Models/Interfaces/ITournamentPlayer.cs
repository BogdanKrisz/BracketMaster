namespace BracketMaster.Models
{
    public interface ITournamentPlayer
    {
        int PlayerId { get; set; }
        int TournamentId { get; set; }
    }
}