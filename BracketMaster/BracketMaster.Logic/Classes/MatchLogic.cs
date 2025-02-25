using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public abstract class MatchLogic
    {
        IRepository<Match> mRepo;

        public MatchLogic(IRepository<Match> matchRepo)
        {
            this.mRepo = matchRepo;
        }

        public virtual void Create(Match item)
        {
            mRepo.Create(item);
        }

        public void Delete(int id)
        {
            mRepo.Delete(id);
        }

        public Match Read(int id)
        {
            return mRepo.Read(id);
        }

        public IQueryable<Match> ReadAll()
        {
            return mRepo.ReadAll();
        }

        public virtual void Update(Match item)
        {
            mRepo.Update(item);
        }

        public virtual void EnterResult(Match item, int homeScore, int awayScore)
        {
            item.SetResult(homeScore, awayScore);
            Update(item);
        }
    }
}
