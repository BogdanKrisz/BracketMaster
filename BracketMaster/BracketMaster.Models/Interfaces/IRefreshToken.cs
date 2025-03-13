
namespace BracketMaster.Models
{
    public interface IRefreshToken
    {
        DateTime Expiration { get; set; }
        Owner Owner { get; set; }
        int OwnerId { get; set; }
        string Token { get; set; }
    }
}