using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{

    // Új kör sorsolása
    // Meccsek leadása
    // Pontszámok számítása / nyilvántartása (Minden playernek kellene erre metódus, amely kiszámolja a saját pont/pohár arányát)
    // lehetőség új körre / Knockout Stage indításra

    // points for win / draw / lose


    // create tournament -> sport választás -> lebony választás
    // kellene egy ilyen tournament készítő logika és onnan az adott lebonyra vezetni
    // tournamentLogic -> swiss/random/roundRobin/groups -> KO

    public abstract class TournamentLogic<T> : ITournamentLogic<T> where T : Tournament
    {
        IRepository<T> tRepo;

        public TournamentLogic(IRepository<T> tournamentRepo)
        {
            this.tRepo = tournamentRepo;
        }

        public virtual void Create(T item)
        {
            if (item == null) throw new ArgumentNullException($"Tournament is null!");
            if (item.Name.Length < 3) throw new ArgumentException($"'{item.Name}' for tournament name is too short!");
            if (item.KnockoutType == null) throw new ArgumentNullException("Knockout type can't be empty!");
            if (item.PreliminaryType == null) throw new ArgumentNullException("Preliminary type can't be empty!");
            if (item.PointsForWin <= 0) throw new ArgumentException("Points for win can't be lower than 1!");
            if (item.PointsForLose >= item.PointsForWin) throw new ArgumentException("Points for lose has to be lower than points for win!");

            tRepo.Create(item);
        }

        public void Delete(int id)
        {
            if (this.Read(id) == null) throw new ArgumentNullException($"Tournament doesn't exist!");

            tRepo.Delete(id);
        }

        public T Read(int id)
        {
            return tRepo.Read(id);
        }

        public IQueryable<T> ReadAll()
        {
            return tRepo.ReadAll();
        }

        public virtual void Update(T item)
        {
            if (item == null) throw new ArgumentNullException($"Tournament is null.");
            if (item.Name.Length < 3) throw new ArgumentException($"'{item.Name}' for tournament name is too short!");
            if (item.PlayersToElimination < 0) throw new ArgumentException("Negative amount of players can't go to elimination!");
            if (item.KnockoutType == null) throw new ArgumentNullException("Knockout type can't be empty!");
            if (item.PreliminaryType == null) throw new ArgumentNullException("Preliminary type can't be empty!");
            if (item.PointsForWin <= 0) throw new ArgumentException("Points for win can't be lower than 1!");
            if (item.PointsForLose >= item.PointsForWin) throw new ArgumentException("Points for lose has to be lower than points for win!");

            tRepo.Update(item);
        }

        // NON CRUD

        public void StartNextRound(Tournament t)
        {
            switch (t.PreliminaryType)
            {
                case RoundRobin:
                    Console.WriteLine("Round Robin next round!");
                    break;
                case Groups:
                    Console.WriteLine("Groups next round!");
                    break;
                case RandomEnemies:
                    Console.WriteLine("Random enemies next round!");
                    break;
                case Swiss:
                    Console.WriteLine("Swiss next round!");
                    break;
            }
        }

        public void StartElimination()
        {
            throw new NotImplementedException();
        }
    }
}
