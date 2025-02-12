using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Repository
{
    public class BeerpongPlayerRepository : Repository<BeerpongPlayer>, IRepository<BeerpongPlayer>
    {
        public BeerpongPlayerRepository(BracketMasterDbContext ctx) : base(ctx)
        {
            
        }
    }
}
