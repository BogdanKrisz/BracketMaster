using BracketMaster.Models;
using BracketMaster.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Service
{
    public interface IGroupService<T, K> : IBasicService<T> 
        where T : Group
        where K : Player
    {
        void AddPlayer(int groupId, int playerId);
    }
}
