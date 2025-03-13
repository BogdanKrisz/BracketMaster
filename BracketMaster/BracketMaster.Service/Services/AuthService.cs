using BracketMaster.Logic;
using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Service
{
    public class AuthService : IAuthService<Owner>
    {
        readonly IOwnerRepository _ownerRepository;
        readonly IAuthLogic _authLogic;

        public AuthService()
        {
            
        }

        #region CRUD
        public void Create(Owner item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Owner Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Owner> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Owner item)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region NON-CRUD
        public bool isAlreadyInUse(string username)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void UpdateUsersRefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Owner GetUserFromHttpHeader(string? header)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
