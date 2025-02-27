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

    public abstract class TournamentLogic<T, K, L> : ITournamentLogic<T>
        where T : Tournament
        where K : TournamentPlayer
        where L : Player
    {
        protected readonly IRepository<T> _tournamentRepo;
        protected readonly ITournamentPlayerLogic<K> _tournamentPlayerLogic;
        protected readonly IPlayerLogic<L> _playerLogic;

        public TournamentLogic(IRepository<T> tournamentRepo, ITournamentPlayerLogic<K> tournamentPlayerLogic, IPlayerLogic<L> playerLogic)
        {
            _tournamentRepo = tournamentRepo;
            _tournamentPlayerLogic = tournamentPlayerLogic;
            _playerLogic = playerLogic;
        }

        public virtual void Create(T item)
        {
            if (item == null) throw new ArgumentNullException($"Tournament is null!");
            if (item.Name.Length < 3) throw new ArgumentException($"'{item.Name}' for tournament name is too short!");
            if (item.KnockoutSystemId < 0) throw new ArgumentNullException("Knockout type is invalid!");
            if (item.PreliminarySystemId < 0) throw new ArgumentNullException("Preliminary type is invalid!");
            if (item.PointsForWin <= 0) throw new ArgumentException("Points for win can't be lower than 1!");
            if (item.PointsForLose >= item.PointsForWin) throw new ArgumentException("Points for lose has to be lower than points for win!");

            _tournamentRepo.Create(item);
        }

        public void Delete(int id)
        {
            if (this.Read(id) == null) throw new ArgumentNullException($"Tournament doesn't exist!");

            _tournamentRepo.Delete(id);
        }

        public T Read(int id)
        {
            return _tournamentRepo.Read(id);
        }

        public IQueryable<T> ReadAll()
        {
            return _tournamentRepo.ReadAll();
        }

        public virtual void Update(T item)
        {
            if (item == null) throw new ArgumentNullException($"Tournament is null.");
            if (item.Name.Length < 3) throw new ArgumentException($"'{item.Name}' for tournament name is too short!");
            if (item.PlayersToElimination < 0) throw new ArgumentException("Negative amount of players can't go to elimination!");
            if (item.KnockoutSystem == null) throw new ArgumentNullException("Knockout type can't be empty!");
            if (item.PreliminarySystem == null) throw new ArgumentNullException("Preliminary type can't be empty!");
            if (item.PointsForWin <= 0) throw new ArgumentException("Points for win can't be lower than 1!");
            if (item.PointsForLose >= item.PointsForWin) throw new ArgumentException("Points for lose has to be lower than points for win!");

            _tournamentRepo.Update(item);
        }

        // NON CRUD

        public void StartNextRound(int tournamentId)
        {
            var t = Read(tournamentId);
            switch (t.PreliminarySystem.Name)
            {
                case "Groups":
                    Console.WriteLine("Groups next round!");
                    break;
                case "Random":
                    Console.WriteLine("Random next round!");
                    break;
                case "Swiss":
                    Console.WriteLine("Swiss next round!");
                    break;
                case "Robin":
                    Console.WriteLine("Round Robin next round!");
                    break;
            }
        }

        public void StartElimination()
        {
            throw new NotImplementedException();
        }

        public abstract void AddPlayer(int tournamentId, int playerId);
    }
}
