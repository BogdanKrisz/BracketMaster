using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public abstract class PlayerLogic<T> : IPlayerLogic<T>
        where T : Player
    {
        readonly IRepository<T> _repository;

        public PlayerLogic(IRepository<T> playerRepo)
        {
            _repository = playerRepo;
        }

        public void Create(T item)
        {
            _repository.Create(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Read(int id)
        {
            return _repository.Read(id);
        }

        public IQueryable<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            _repository.Update(item);
        }      
    }
}
