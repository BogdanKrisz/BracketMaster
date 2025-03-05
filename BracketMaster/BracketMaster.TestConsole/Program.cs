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
                
                .AddScoped<BracketMasterDbContext>()

                .AddScoped<ITournamentRepository<BeerpongTournament>, BeerpongTournamentRepository>()
                .AddScoped<IPlayerRepository<BeerpongPlayer>, BeerpongPlayerRepository>()

                .AddScoped<ITournamentLogic<BeerpongTournament>, BeerpongTournamentLogic>()
                .AddScoped<IPlayerLogic<BeerpongPlayer>, BeerpongPlayerLogic>()
                .AddScoped<GroupsLogic>()
                .AddScoped<RandomEnemyLogic>()
                .AddScoped<SwissLogic>()
                .AddScoped<RoundRobinLogic>()
                .AddScoped<PreliminaryHandlerFactory>()
                .AddScoped<NoneEleminationLogic>()
                .AddScoped<SingleEleminationLogic>()
                .AddScoped<DoubleEleminationLogic>()
                .AddScoped<TripleEleminationLogic>()
                .AddScoped<KnockoutHandlerFactory>()
                .AddScoped(typeof(ITournamentService<>), typeof(TournamentService<>))
                .AddScoped(typeof(IPlayerService<>), typeof(PlayerService<>))
                .BuildServiceProvider();

            var bpService = serviceProvider.GetRequiredService<ITournamentService<BeerpongTournament>>();
            var pService = serviceProvider.GetRequiredService<IPlayerService<BeerpongPlayer>>();

            // initialize db data
            var ctx = serviceProvider.GetRequiredService<BracketMasterDbContext>();
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

            bpService.Create(t1);

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

            pService.Create(p1);
            pService.Create(p2);
            pService.Create(p3);
            pService.Create(p4);


            bpService.AddPlayer(1, 1);
            bpService.AddPlayer(1, 2);
            bpService.AddPlayer(1, 3);
            bpService.AddPlayer(1, 4);

            // player adása bajnoksághoz
            //bpTLogic.AddPlayer(1, 1);
            //bpTLogic.AddPlayer(1, 2);
            //bpTLogic.AddPlayer(1, 3);
            //bpTLogic.AddPlayer(1, 4);

            //ITournamentRepository<BeerpongTournament> bpTournamentRepo = new BeerpongTournamentRepository(ctx);

            //tournamentService.StartTournament(1);
        }
    }
}
