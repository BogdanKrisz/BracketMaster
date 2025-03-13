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
        void RegisterOwner(RegisterModel newUser);
        bool usernameAlreadyInUse(string username);
        bool ValidateUser(string username, string givenPassword);
        void UpdateUsersRefreshToken(RefreshToken newToken, Owner owner);
        Owner GetOwnerFromHttpHeader(string? header);
    }
}
