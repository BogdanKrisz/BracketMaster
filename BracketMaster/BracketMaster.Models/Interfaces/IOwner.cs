
namespace BracketMaster.Models
{
    public interface IOwner
    {
        
        string Username { get; set; }
        string PasswordHashed { get; set; }
        string PasswordSalt { get; set; }
        int PasswordIterationCount { get; set; }

        string Email { get; set; }
        
        int? RefreshTokenId { get; set; }
        RefreshToken? RefreshToken { get; set; }

        ICollection<Tournament> Tournaments { get; set; }
    }
}