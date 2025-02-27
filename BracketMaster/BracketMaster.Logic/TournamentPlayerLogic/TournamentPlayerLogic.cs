using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public abstract class TournamentPlayerLogic<T> : ITournamentPlayerLogic<T>
        where T : TournamentPlayer
    {
        readonly IRepository<T> _repository;

        public TournamentPlayerLogic(IRepository<T> tournamentPlayerRepo)
        {
            _repository = tournamentPlayerRepo;
        }

        public void Create(T item)
        {
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
            _repository.Update(item);
        }
    }
}
