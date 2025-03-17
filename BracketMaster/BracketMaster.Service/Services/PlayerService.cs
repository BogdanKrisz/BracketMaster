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
    public class PlayerService<P> : IPlayerService<P>
        where P : Player
    {
        readonly IPlayerRepository<P> _playerRepository;
        readonly IPlayerLogic<P> _playerLogic;

        public PlayerService(
            IPlayerRepository<P> playerRepository,
            IPlayerLogic<P> playerLogic)
        {
            _playerRepository = playerRepository;
            _playerLogic = playerLogic;
        }



        public void Create(P item)
        {
            try
            {
                _playerLogic.Validate(item);
                _playerRepository.Create(item);
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
                _playerRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public P Read(int id)
        {
            try
            {
                return _playerRepository.Read(id);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<P> ReadAll()
        {
            try
            {
                return _playerRepository.ReadAll();
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void Update(P item)
        {
            try
            {
                _playerLogic.Validate(item);
                _playerRepository.Update(item);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }
    }
}
