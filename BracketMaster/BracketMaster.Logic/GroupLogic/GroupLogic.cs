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
        // !!!! fontos !!! - először grouppokat kell majd létrehozni, bele embereket és csak aztán jöhetnek a meccsek a tournamentekbe (ha van csoport már és benne az emberek, akkor a groupba is beleteszi a meccset)
        protected GroupLogic()
        {

        }

        public virtual void Validate(T item)
        {

        }
    }
}
