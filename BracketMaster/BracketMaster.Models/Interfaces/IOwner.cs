
namespace BracketMaster.Models
{
    public interface IOwner
    {
        string Email { get; set; }
        string? HashedPassword { get; set; }
        string? Password { get; set; }
        string? PasswordSalt { get; set; }
        ICollection<Tournament> Tournaments { get; set; }
        string Username { get; set; }

        int? RefreshTokenId { get; set; }
        RefreshToken? RefreshToken { get; set; }
    }
}