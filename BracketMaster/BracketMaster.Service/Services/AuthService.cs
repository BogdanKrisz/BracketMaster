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
        readonly IRepository<Owner> _ownerRepository;
        readonly IAuthLogic _authLogic;
        
        readonly IRepository<RefreshToken> _refreshTokenRepository;
        readonly ITokenService _tokenService;

        public AuthService(IRepository<Owner> ownerRepository, IAuthLogic authLogic)
        {
            _ownerRepository = ownerRepository;
            _authLogic = authLogic;
        }

        #region CRUD
        public void Create(Owner item)
        {
            try
            {
                _authLogic.Validate(item);
                _ownerRepository.Create(item);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(int id)
        {
            try
            {
                _ownerRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public Owner Read(int id)
        {
            try
            {
                return _ownerRepository.Read(id);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<Owner> ReadAll()
        {
            try
            {
                return _ownerRepository.ReadAll();
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void Update(Owner item)
        {
            try
            {
                _authLogic.Validate(item);
                _ownerRepository.Update(item);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #region NON-CRUD
        public bool isAlreadyInUse(string username)
        {
            try
            {
                
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public bool ValidateUser(string username, string password)
        {
            try
            {

            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void UpdateUsersRefreshToken(string refreshToken)
        {
            try
            {

            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public Owner GetUserFromHttpHeader(string? header)
        {
            try
            {

            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }
        #endregion
    }
}
