using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public abstract class TournamentPlayerLogic<T> : ITournamentPlayerLogic<T> where T : TournamentPlayer
    {
        protected TournamentPlayerLogic()
        {
            
        }

        public virtual void Validate(T item)
        {
            throw new NotImplementedException();
        }
    }
}
