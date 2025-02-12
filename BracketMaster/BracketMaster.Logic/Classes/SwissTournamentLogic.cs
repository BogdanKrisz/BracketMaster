using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic.Classes
{
    public class SwissTournamentLogic : ITournamentLogic
    {
        IRepository<Tournament> tRepo;
        IRepository<Player> pRepo;

        public SwissTournamentLogic(IRepository<Tournament> tournamentRepo, IRepository<Player> playerRepo)
        {
            this.tRepo = tournamentRepo;
            this.pRepo = playerRepo;
        }

        public void Create(Tournament item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void GenerateNextRound()
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
