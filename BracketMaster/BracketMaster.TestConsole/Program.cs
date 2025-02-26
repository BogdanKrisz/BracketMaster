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
            BeerpongTournamentLogic bpTLogic = new BeerpongTournamentLogic(bpongRepo);

            // initialize db data
            DbInitializer.Initialize(ctx);

            // 
            BeerpongTournament nT = new BeerpongTournament()
            {
                Name = "Elite PreSeason #2",
                KnockoutSystemId = 0,
                PreliminarySystemId = 0,
                PointsForWin = 3,
                PointsForOverTimeWin = 2,
                PointsForOverTimeLose = 1,
                PointsForLose = 0,
            };
            bpTLogic.AddPlayer(new BeerpongPlayer() { Name = "Játékos1" });
            bpongRepo.Create(nT);

            BeerpongTournamentLogic bpLogic = new BeerpongTournamentLogic(bpongRepo);
        }
    }
}
