using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Repository
{
    public static class DbInitializer
    {
        public static void Initialize(BracketMasterDbContext ctx)
        {
            if(!ctx.KnockoutSystems.Any())
            {
                ctx.KnockoutSystems.AddRange(
                    new Models.KnockoutSystem { Name = "None", Description = "No elimination occurs; all participants continue playing regardless of losses." },
                    new Models.KnockoutSystem { Name = "Single", Description = "A team is eliminated after losing one match." },
                    new Models.KnockoutSystem { Name = "Double", Description = "A team is eliminated after losing two matches." },
                    new Models.KnockoutSystem { Name = "Triple", Description = "A team is eliminated after losing three matches." }
                );
            }

            if (!ctx.PreliminarySystems.Any())
            {
                ctx.PreliminarySystems.AddRange(
                    new Models.PreliminarySystem { Name = "Groups", Description = "Teams are divided into groups, and the best from each group advance." },
                    new Models.PreliminarySystem { Name = "Random", Description = "Matches are assigned randomly without a structured system." },
                    new Models.PreliminarySystem { Name = "Swiss", Description = "Teams play a set number of rounds against opponents with similar records." },
                    new Models.PreliminarySystem { Name = "Robin", Description = "Every team plays against every other team at least once." }
                );
            }

            if (!ctx.BeerpongOvertimeTypes.Any())
            {
                ctx.BeerpongOvertimeTypes.AddRange(
                    new Models.BeerpongOvertimeType { Name = "None", Description = "No possibility for overtime, the game goes until sudden death." },
                    new Models.BeerpongOvertimeType { Name = "Basic", Description = "After the game, regardless the number of overtimes, the cup difference will be added to the winner and subtracted from the loser." },
                    new Models.BeerpongOvertimeType { Name = "BPBL", Description = "After overtime happens, regardless of the result, noone wins or loses cups." },
                    new Models.BeerpongOvertimeType { Name = "ESOBP", Description = "When the teams reached the second over time (16hits for someone) the cup difference will be only 1 no matter of the result." }
                );
            }

            ctx.SaveChanges();
        }
    }
}
