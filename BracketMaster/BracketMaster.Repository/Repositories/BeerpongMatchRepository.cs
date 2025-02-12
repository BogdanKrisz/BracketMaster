using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Repository
{
    public class BeerpongMatchRepository : Repository<BeerpongMatch>, IRepository<BeerpongMatch>
    {
        public BeerpongMatchRepository(BracketMasterDbContext ctx) : base(ctx)
        {

        }
    }
}
