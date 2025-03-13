using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Repository
{
    public class OwnerRepository : Repository<Owner>, IRepository<Owner>
    {
        public OwnerRepository(BracketMasterDbContext ctx) : base(ctx)
        {
        }
    }
}
