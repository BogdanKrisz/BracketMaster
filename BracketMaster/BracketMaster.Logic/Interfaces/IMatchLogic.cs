using BracketMaster.Models;

namespace BracketMaster.Logic
{
    public interface IMatchLogic<T> where T : Match
    {
        void Validate(T item);
    }
}