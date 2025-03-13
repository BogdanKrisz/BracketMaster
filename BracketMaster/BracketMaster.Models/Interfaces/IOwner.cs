
namespace BracketMaster.Models
{
    public interface IOwner
    {
        
        string Username { get; set; }
        string HashedPassword { get; set; }
        string PasswordSalt { get; set; }
        string IterationCount { get; set; }

        string Email { get; set; }
        
        int? RefreshTokenId { get; set; }
        RefreshToken? RefreshToken { get; set; }

        ICollection<Tournament> Tournaments { get; set; }
    }
}