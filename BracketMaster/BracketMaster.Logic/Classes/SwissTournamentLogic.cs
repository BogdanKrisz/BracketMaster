using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic.Classes
{
    public class SwissTournamentLogic : TournamentLogic, ITournamentLogic
    {
        IRepository<Player> pRepo;

        public SwissTournamentLogic(IRepository<Tournament> tournamentRepo, IRepository<Player> playerRepo)
            : base(tournamentRepo)
        {
            this.pRepo = playerRepo;
        }

        public override void GenerateNextRound()
        {

            // Arra figyelj ! -> hogy olyan játékos ne legyen ellenfél, aki már játszik valakivel a most éppen generálás allti körben
            // Arra is figyeljünk, hogy ne maradjon ki valaki 2x, szóval páratlan enemynél ha valaki kimarad, utána addig ne maradjon ki, amíg nem lesz mindenki ugyanannyi meccsszámon
            // Nem dob össze ugyanazzal az ellenféllel, ha még van akivel nem játszott

            // Ha már mindenkivel játszott az illető 1szer, akkor az eredeti ellenfelével jöhet



            throw new NotImplementedException();
        }
    }
}
