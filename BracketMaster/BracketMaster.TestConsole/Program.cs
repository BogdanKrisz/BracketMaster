using BracketMaster.Logic;
using BracketMaster.Models;
using BracketMaster.Repository;
using BracketMaster.Repository.Repositories;
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

                // repos
                .AddScoped<ITournamentRepository<BeerpongTournament>, BeerpongTournamentRepository>()
                .AddScoped<IPlayerRepository<BeerpongPlayer>, BeerpongPlayerRepository>()
                .AddScoped<IMatchRepository<BeerpongMatch>, BeerpongMatchRepository>()
                .AddScoped<IGroupRepository<BeerpongGroup>, BeerpongGroupRepository>()

                .AddScoped<IRepository<Owner>, OwnerRepository>()
                .AddScoped<IRepository<RefreshToken>, RefreshTokenRepository>()

                // Logics
                .AddScoped<ITournamentLogic<BeerpongTournament>, BeerpongTournamentLogic>()
                .AddScoped<IPlayerLogic<BeerpongPlayer>, BeerpongPlayerLogic>()
                .AddScoped<IMatchLogic<BeerpongMatch>, BeerpongMatchLogic>()
                .AddScoped<IGroupLogic<BeerpongGroup>, BeerpongGroupLogic>()
                .AddScoped<IAuthLogic, AuthLogic>()
                .AddScoped<IPasswordHasher, PasswordHasher>()

                // Preliminary Logics
                .AddScoped<GroupsLogic>()
                .AddScoped<RandomEnemyLogic>()
                .AddScoped<SwissLogic>()
                .AddScoped<RoundRobinLogic>()

                // Knockout Logics
                .AddScoped<NoneEleminationLogic>()
                .AddScoped<SingleEleminationLogic>()
                .AddScoped<DoubleEleminationLogic>()
                .AddScoped<TripleEleminationLogic>()

                // Factories
                .AddScoped<PreliminaryHandlerFactory>()
                .AddScoped<KnockoutHandlerFactory>()

                // Services

                .AddScoped(typeof(ITournamentService<,,,>), typeof(TournamentService<,,,>))
                .AddScoped(typeof(IPlayerService<,,>), typeof(PlayerService<,,>))
                .AddScoped(typeof(IMatchService<>), typeof(MatchService<>))
                .AddScoped(typeof(IGroupService<>), typeof(GroupService<>))
                .AddScoped<IAuthService<Owner>, AuthService>()

                // tokenService
                //.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
                .AddScoped<ITokenService, TokenService>()

                .BuildServiceProvider();

            var bpService = serviceProvider.GetRequiredService<ITournamentService<BeerpongTournament,BeerpongPlayer,BeerpongGroup,BeerpongMatch>>();
            var pService = serviceProvider.GetRequiredService<IPlayerService<BeerpongPlayer,BeerpongGroup,BeerpongMatch>>();
            var matchService = serviceProvider.GetRequiredService<IMatchService<BeerpongMatch>>();
            var authService = serviceProvider.GetRequiredService<IAuthService<Owner>>();

            // initialize db data
            var ctx = serviceProvider.GetRequiredService<BracketMasterDbContext>();
            DbInitializer.Initialize(ctx);

            authService.RegisterOwner(new RegisterModel { Username = "KriszOwner", Email = "proba@gmail.com", Password = "Jelszo" });

            // új bajnokság
            BeerpongTournament t1 = new BeerpongTournament()
            {
                OwnerId = 1,
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

            bpService.AddPlayerToTournament(1, 1);
            bpService.AddPlayerToTournament(1, 2);
            bpService.AddPlayerToTournament(1, 3);
            bpService.AddPlayerToTournament(1, 4);

            BeerpongGroup bpG1 = new BeerpongGroup() { Name = "A csoport", TournamentId = 1 };
            BeerpongGroup bpG2 = new BeerpongGroup() { Name = "B csoport", TournamentId = 1 };

            bpService.CreateGroup(bpG1);
            bpService.CreateGroup(bpG2);

            bpService.AddPlayerToGroup(1, 1);
            bpService.AddPlayerToGroup(1, 2);

            bpService.AddPlayerToGroup(2, 3);
            bpService.AddPlayerToGroup(2, 4);

            bpService.CreateMatch(new BeerpongMatch() { TournamentId = 1, HomeId = 1, AwayId = 2 });
            bpService.CreateMatch(new BeerpongMatch() { TournamentId = 1, HomeId = 3, AwayId = 4 });

            bpService.AddMatchToTournament(1, 1);
            bpService.AddMatchToTournament(1, 2);

            matchService.SetResult(1, 10, 8);
            matchService.SetResult(2, 18, 19);

            bpService.RemovePlayerFromTournament(1);
            bpService.RemovePlayerFromTournament(2);

            bpService.RemovePlayerFromGroup(3);

            // Grouppoknál meccsek kiírása ??
            // grouppoknál playerek kiírása ??



            // csoportoknál a ranglista alapú egyenes kiesésnél 
            // jó lenne egy feature, ahol alapból beállított meccs számig megy a preliminary, de van egy gomb arra, hogy generáljon +ba kört minden kör végén
        }
    }
}
