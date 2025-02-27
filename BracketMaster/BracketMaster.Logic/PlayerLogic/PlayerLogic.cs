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
            if (item.Name == null) throw new ArgumentNullException("The name can't be empty!");

            _repository.Create(item);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public T Read(int id)
        {
            return _repository.Read(id);
        }

        public IQueryable<T> ReadAll()
        {
            return _repository.ReadAll();
        }

        public void Update(T item)
        {
            if (item.Name == null) throw new ArgumentNullException("The name can't be empty!");

            _repository.Update(item);
        }      
    }
}
