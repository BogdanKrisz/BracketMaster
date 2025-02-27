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
