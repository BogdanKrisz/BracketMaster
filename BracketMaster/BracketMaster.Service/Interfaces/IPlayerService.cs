using BracketMaster.Models;
using BracketMaster.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Service
{
    public interface IPlayerService<T, G, M> : IBasicService<T> 
        where T : Player
        where G : Group
        where M : Match
    {
    }
}
