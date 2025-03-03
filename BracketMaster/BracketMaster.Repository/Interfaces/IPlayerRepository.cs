using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Repository
{
    public interface IPlayerRepository<T> : IRepository<T> where T : Player
    {
    }
}
