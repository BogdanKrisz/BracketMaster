using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public abstract class MatchLogic<M, P> : IMatchLogic<M, P>
        where M : Match
        where P : Player
    {
        protected MatchLogic()
        {

        }

        public abstract P AddPointsToPlayer(M match, P player);

        public abstract int CountMatchPoints(M m, P p);

        public virtual void Validate(M item)
        {
            
        }
    }
}
