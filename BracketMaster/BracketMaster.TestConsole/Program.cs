using BracketMaster.Logic;
using BracketMaster.Models;
using BracketMaster.Repository;
using BracketMaster.Service;

namespace BracketMaster.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BracketMasterDbContext ctx = new BracketMasterDbContext();
            var bpongTournaments = ctx.BeerpongTournaments;
            var bpongRepo = new BeerpongTournamentRepository(ctx);
            var bpongTournamentPlayerRepo = new BeerpongTournamentPlayerRepository(ctx);
            var bpongTournamentPlayerLogic = new BeerpongTournamentPlayerLogic(bpongTournamentPlayerRepo);
            var bpongPlayerRepo = new BeerpongPlayerRepository(ctx);
            var bpongPlayerLogic = new BeerpongPlayerLogic(bpongPlayerRepo);
            BeerpongTournamentLogic bpTLogic = new BeerpongTournamentLogic(bpongRepo, bpongTournamentPlayerLogic, bpongPlayerLogic);

            // initialize db data
            DbInitializer.Initialize(ctx);

            // új bajnokság
            BeerpongTournament t1 = new BeerpongTournament()
            {
                Name = "Elite PreSeason #2",
                KnockoutSystemId = 1,
                PreliminarySystemId = 1,
                PointsForWin = 3,
                PointsForOverTimeWin = 2,
                PointsForOverTimeLose = 1,
                PointsForLose = 0
            };
            bpTLogic.Create(t1);

            // új player
            BeerpongPlayer p1 = new BeerpongPlayer()
            {
                Name = "Krisz"
            };

            BeerpongPlayer p2 = new BeerpongPlayer()
            {
                Name = "Erik"
            };

            BeerpongPlayer p3 = new BeerpongPlayer()
            {
                Name = "Roló"
            };

            BeerpongPlayer p4 = new BeerpongPlayer()
            {
                Name = "Szonja"
            };
            bpongPlayerLogic.Create(p1);
            bpongPlayerLogic.Create(p2);
            bpongPlayerLogic.Create(p3);
            bpongPlayerLogic.Create(p4);

            // player adása bajnoksághoz
            bpTLogic.AddPlayer(1, 1);
            bpTLogic.AddPlayer(1, 2);
            bpTLogic.AddPlayer(1, 3);
            bpTLogic.AddPlayer(1, 4);

            ITournamentRepository<BeerpongTournament> bpTournamentRepo = new BeerpongTournamentRepository(ctx);
            IKnockoutLogic koLogic = new SingleEleminationLogic();
            TournamentService<BeerpongTournament> bpService = new TournamentService<BeerpongTournament>(bpTournamentRepo, koLogic);
            bpService.StartTournament(1);
        }
    }
}
