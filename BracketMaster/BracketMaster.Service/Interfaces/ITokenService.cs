using BracketMaster.Models;
using System.Security.Claims;

namespace BracketMaster.Service
{
    public interface ITokenService
    {
        string GenerateJwtToken(string username);
        RefreshToken GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        string GetUsernameFromToken(string token);
        bool IsTokenExpired(string token);
    }
}