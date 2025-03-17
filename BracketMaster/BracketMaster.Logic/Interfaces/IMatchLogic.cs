using BracketMaster.Models;

namespace BracketMaster.Logic
{
    public interface IMatchLogic<M, P> 
        where M : Match
        where P : Player
    {
        P AddPointsToPlayer(M match, P player);
        int CountMatchPoints(M match, P player);
        void Validate(M item);
    }
}