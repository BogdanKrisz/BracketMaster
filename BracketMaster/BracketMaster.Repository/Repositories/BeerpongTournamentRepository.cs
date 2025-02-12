using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Repository
{
    public class BeerpongTournamentRepository : Repository<BeerpongTournament>, IRepository<BeerpongTournament>
    {
        public BeerpongTournamentRepository(BracketMasterDbContext ctx) : base(ctx)
        {

        }
    }
}
