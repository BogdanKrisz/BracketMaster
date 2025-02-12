using BracketMaster.Logic;
using BracketMaster.Models;
using BracketMaster.Repository;

namespace BracketMaster.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            var ctx = new BracketMasterDbContext();
            var bpPlayerRepo = new BeerpongPlayerRepository(ctx);
            //var playerLogic = new PlayerLogic(pRepo);
            var players = ctx.Players;
            */

            BeerpongTournament t1 = new BeerpongTournament() { Name = "Teszt", PointsForWin = 3, PointsForOverTimeWin = 2, PointsForOverTimeLose = 1, PointsForLose = 0, KnockoutType = KnockoutType.Single, PrelimineryType = PrelimineryType.Swiss };

            
            List<BeerpongPlayer> beerpongPlayers = new List<BeerpongPlayer>
            {
                new BeerpongPlayer { Id = 0, Name = "Harmadik", Tournament = t1 },
                new BeerpongPlayer { Id = 1, Name = "Masodik", Tournament = t1 },
                new BeerpongPlayer { Id = 2, Name = "Elso", Tournament = t1},
                new BeerpongPlayer { Id = 3, Name = "Negyedik", Tournament = t1}
            };

            t1.Players = beerpongPlayers.Cast<Player>().ToList();

            BeerpongMatch m1 = new BeerpongMatch { Home = beerpongPlayers[0], HomeId = beerpongPlayers[0].Id, Away = beerpongPlayers[1], AwayId = beerpongPlayers[1].Id, Round = 1, Tournament = t1 };
            BeerpongMatch m2 = new BeerpongMatch { Home = beerpongPlayers[2], HomeId = beerpongPlayers[2].Id, Away = beerpongPlayers[3], AwayId = beerpongPlayers[3].Id, Round = 1, Tournament = t1 };

            m1.SetResult(12, 13);
            m2.SetResult(10, 9);

            beerpongPlayers[0].HomeMatches.Add(m1);
            beerpongPlayers[1].AwayMatches.Add(m1);
            beerpongPlayers[2].HomeMatches.Add(m2);
            beerpongPlayers[3].AwayMatches.Add(m2);

            Console.WriteLine(beerpongPlayers[0].Points);
            Console.WriteLine(beerpongPlayers[1].Points);
            Console.WriteLine(beerpongPlayers[2].Points);
            Console.WriteLine(beerpongPlayers[3].Points);
        }
    }
}
