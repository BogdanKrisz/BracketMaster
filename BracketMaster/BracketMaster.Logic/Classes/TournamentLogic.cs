using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    // Fajták
    // lehessen kiválasztani, hogy hány preliminery kör legyen

    // RoundRobin
    // Swiss-system -> ismétlések kerülése, ha lehetséges
    // Random enemy -> ismétlések kerülése, ha lehetséges
    // battle royale

    // egyenes kiesés
    // single elimination
    // double elimination

        // Seedelési lehetőségek
        // 1-8, 2-7 ...
        // random
        // nem tudom mik vannak még


    // Új kör sorsolása
    // Meccsek leadása
    // Pontszámok számítása / nyilvántartása (Minden playernek kellene erre metódus, amely kiszámolja a saját pont/pohár arányát)
    // lehetőség új körre / Knockout Stage indításra

    // points for win / draw / lose
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
