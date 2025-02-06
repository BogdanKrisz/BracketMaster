using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public class TournamentLogic : ITournamentLogic
    {
        IRepository<Tournament> tRepo;

        public TournamentLogic(IRepository<Tournament> tournamentRepo)
        {
            this.tRepo = tournamentRepo;
        }

        public void Create(Tournament item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Tournament Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tournament> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Tournament item)
        {
            throw new NotImplementedException();
        }
    }
}
