using BracketMaster.Models;

namespace BracketMaster.Logic
{
    public interface ITournamentPlayerLogic<T> : IBaseLogic<T> 
        where T : TournamentPlayer
    {
    }
}