using BracketMaster.Logic;
using BracketMaster.Models;
using BracketMaster.Repository;

namespace BracketMaster.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BracketMasterDbContext ctx = new BracketMasterDbContext();
            var bpongTournaments = ctx.BeerpongTournaments;
            var bpongRepo = new BeerpongTournamentRepository(ctx);

            DbInitializer.Initialize(ctx);

            BeerpongTournamentLogic bpLogic = new BeerpongTournamentLogic(bpongRepo);
        }
    }
}
