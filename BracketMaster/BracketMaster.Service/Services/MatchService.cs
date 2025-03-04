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
    public class MatchService<T> : IMatchService<T> where T : Match
    {
        readonly IMatchRepository<T> _matchRepository;
        readonly IMatchLogic<T> _matchLogic;

        public MatchService(IMatchRepository<T> matchRepository, IMatchLogic<T> matchLogic)
        {
            _matchRepository = matchRepository;
            _matchLogic = matchLogic;
        }

        public void Create(T item)
        {
            throw new NotImplementedException();
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
