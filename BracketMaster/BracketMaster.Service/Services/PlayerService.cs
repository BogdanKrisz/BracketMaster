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
    public class PlayerService<T> : IPlayerService<T> where T : Player
    {
        readonly IPlayerRepository<T> _playerRepository;
        readonly IPlayerLogic<T> _playerLogic;

        public PlayerService(IPlayerRepository<T> playerRepository, IPlayerLogic<T> playerLogic)
        {
            _playerRepository = playerRepository;
            _playerLogic = playerLogic;
        }

        public void Create(T item)
        {
            _playerLogic.Validate(item);
            _playerRepository.Create(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
