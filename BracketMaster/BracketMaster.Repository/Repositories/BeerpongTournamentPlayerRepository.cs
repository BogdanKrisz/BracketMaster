using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Repository
{
    public class BeerpongTournamentPlayerRepository : Repository<BeerpongTournamentPlayer>, ITournamentPlayerRepository<BeerpongTournamentPlayer>
    {
        public BeerpongTournamentPlayerRepository(BracketMasterDbContext ctx) : base(ctx)
        {

        }
    }
}
