using BracketMaster.Logic;
using BracketMaster.Repository;

namespace BracketMaster.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ctx = new BracketMasterDbContext();
            var bpPlayerRepo = new BeerpongPlayerRepository(ctx);
            var playerLogic = new PlayerLogic(pRepo);
            var players = ctx.Players;
            
        }
    }
}
