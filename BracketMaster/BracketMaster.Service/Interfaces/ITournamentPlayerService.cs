using BracketMaster.Models;
using BracketMaster.Service.Interfaces;

namespace BracketMaster.Service
{
    public interface ITournamentPlayerService<T> : IBasicService<T> where T : TournamentPlayer
    {
    }
}