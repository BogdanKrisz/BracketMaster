using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Repository
{
    public class MatchRepository : Repository<Match>, IRepository<Match>
    {
        public MatchRepository(BracketMasterDbContext ctx) : base(ctx)
        {

        }
    }
}
