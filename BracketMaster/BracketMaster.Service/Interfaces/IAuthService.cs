using BracketMaster.Models;
using BracketMaster.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Service
{
    public interface IAuthService<T> : IBasicService<T> where T : Owner
    {
        bool isAlreadyInUse(string username);
        bool ValidateUser(string username, string password);
        void UpdateUsersRefreshToken(string refreshToken);
        Owner GetUserFromHttpHeader(string? header);
    }
}
