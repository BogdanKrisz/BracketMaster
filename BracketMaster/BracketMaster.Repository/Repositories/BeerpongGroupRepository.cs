using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Repository.Repositories
{
    public class BeerpongGroupRepository : Repository<BeerpongGroup>, IGroupRepository<BeerpongGroup>
    {
        public BeerpongGroupRepository(BracketMasterDbContext ctx) : base(ctx)
        {
        }
    }
}
