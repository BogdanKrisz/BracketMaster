using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public abstract class GroupLogic<T> : IGroupLogic<T> where T : Group
    {
        protected GroupLogic()
        {

        }

        public virtual void Validate(T item)
        {

        }
    }
}
