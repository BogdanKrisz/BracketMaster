using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public abstract class MatchLogic<T> : IMatchLogic<T> where T : Match
    {
        protected MatchLogic()
        {

        }

        public virtual void Validate(T item)
        {
            
        }
    }
}
