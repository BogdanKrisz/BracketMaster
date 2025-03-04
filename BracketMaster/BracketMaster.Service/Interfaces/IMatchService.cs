using BracketMaster.Models;
using BracketMaster.Service.Interfaces;

namespace BracketMaster.Service
{
    public interface IMatchService<T> : IBasicService<T> where T : Match
    {
    }
}