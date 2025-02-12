using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public abstract class MatchLogic : IMatchLogic
    {
        IRepository<Match> mRepo;

        public MatchLogic(IRepository<Match> matchRepo)
        {
            this.mRepo = matchRepo;
        }

        public void Create(Match item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Match Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Match> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Match item)
        {
            throw new NotImplementedException();
        }


        public void EnterResult(int homeScore, int awayScore)
        {
            throw new NotImplementedException();
        }
    }
}
