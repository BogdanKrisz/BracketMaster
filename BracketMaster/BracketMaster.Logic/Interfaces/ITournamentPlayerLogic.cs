using BracketMaster.Models;

namespace BracketMaster.Logic
{
    public interface ITournamentPlayerLogic<T> where T : TournamentPlayer
    {
        void Validate(T item);
    }
}