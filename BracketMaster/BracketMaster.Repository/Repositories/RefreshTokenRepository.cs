using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Repository
{
    public class RefreshTokenRepository : Repository<RefreshToken>, IRepository<RefreshToken>
    {
        public RefreshTokenRepository(BracketMasterDbContext ctx) : base(ctx)
        {
        }
    }
}
