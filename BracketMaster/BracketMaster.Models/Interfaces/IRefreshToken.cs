
namespace BracketMaster.Models
{
    public interface IRefreshToken
    {
        string Token { get; set; }
        DateTime Expiration { get; set; }
        int? OwnerId { get; set; }
        Owner? Owner { get; set; }
    }
}