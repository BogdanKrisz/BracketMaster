using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Repository
{
    public class TournamentRepository : Repository<Tournament>, IRepository<Tournament>
    {
        public TournamentRepository(BracketMasterDbContext ctx) : base(ctx)
        {

        }
    }
}
