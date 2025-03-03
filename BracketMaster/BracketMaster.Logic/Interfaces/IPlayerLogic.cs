using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public interface IPlayerLogic<T> where T : Player
    {
        void Validate(T item);
    }
}
