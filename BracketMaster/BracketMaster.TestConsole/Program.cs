using BracketMaster.Logic;
using BracketMaster.Models;
using BracketMaster.Repository;
using BracketMaster.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BracketMaster.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped(typeof(ITournamentService<>), typeof(TournamentService<>))
                .BuildServiceProvider();

            var knockoutService = serviceProvider.GetRequiredService<ITournamentService<KnockoutSystem>>();

            BracketMasterDbContext ctx = new BracketMasterDbContext();

            var bpTournamentRepo = new BeerpongTournamentRepository(ctx);
            IKnockoutLogic koLogic = new SingleEleminationLogic();
            IPreliminaryLogic preLogic = new RandomEnemyLogic();
            TournamentService<BeerpongTournament> tournamentService = new TournamentService<BeerpongTournament>(bpTournamentRepo, koLogic, preLogic);

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

            tournamentService.Create(t1);


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

            tournamentService.StartTournament(1);
        }
    }
}
