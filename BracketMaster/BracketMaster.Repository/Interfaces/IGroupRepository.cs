using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Repository
{
    public interface IGroupRepository<T> : IRepository<T> where T : Group
    {
    }
}
