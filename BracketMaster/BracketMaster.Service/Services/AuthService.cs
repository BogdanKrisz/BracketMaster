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

        readonly IPasswordHasher _passwordHasher;

        public AuthService(IRepository<Owner> ownerRepository, IAuthLogic authLogic, IPasswordHasher passwordHasher)
        {
            _ownerRepository = ownerRepository;
            _authLogic = authLogic;
            _passwordHasher = passwordHasher;
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

        public Owner Read(string username)
        {
            try
            {
                return _ownerRepository.ReadAll().FirstOrDefault(x => x.Username == username);
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
        public void RegisterOwner(RegisterModel newUser)
        {
            try
            {
                // logic helye..

                var passwordHash = _passwordHasher.HashPassword(newUser.Password);
                var parts = passwordHash.Split(':');

                Owner owner = new()
                {
                    Username = newUser.Username,
                    PasswordHashed = parts[0],
                    PasswordSalt = parts[1],
                    PasswordIterationCount = int.Parse(parts[2]),
                    Email = newUser.Email
                };

                _ownerRepository.Create(owner);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        
        public bool usernameAlreadyInUse(string username)
        {
            try
            {
                Owner owner = Read(username);
                return owner != null;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public bool ValidateUser(string username, string givenPassword)
        {
            try
            {
                Owner owner = Read(username);
                if (owner != null) throw new Exception("Owner not found!");

                string storedHash = $"{owner.PasswordHashed}:{owner.PasswordSalt}:{owner.PasswordIterationCount}";
                return owner != null && _passwordHasher.VerifyPassword(givenPassword, storedHash);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void UpdateUsersRefreshToken(RefreshToken newToken, Owner owner)
        {
            try
            {
                if(owner.RefreshToken == null)
                {
                    newToken.OwnerId = owner.Id;
                    _refreshTokenRepository.Create(newToken);
                }
                else
                {
                    RefreshToken oldRefreshToken = _refreshTokenRepository.Read((int)owner.RefreshTokenId);
                    oldRefreshToken.Token = newToken.Token;
                    oldRefreshToken.Expiration = newToken.Expiration;
                    _refreshTokenRepository.Update(oldRefreshToken);
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public Owner GetOwnerFromHttpHeader(string? header)
        {
            try
            {
                var token = header.Substring("Bearer ".Length).Trim();
                string username = _tokenService.GetUsernameFromToken(token);
                Owner owner = ReadAll().FirstOrDefault(u => u.Username == username);
                if (owner == null) throw new Exception("Owner not found");
                return owner;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }
        #endregion
    }
}
