using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic.Classes
{
    public class BeerpongTournamentLogic : TournamentLogic<BeerpongTournament>
    {
        public BeerpongTournamentLogic(IRepository<BeerpongTournament> tournamentRepo) : base(tournamentRepo)
        {

        }

        public override void Create(BeerpongTournament item)
        {
            if (item.PointsForOverTimeWin < item.PointsForOverTimeLose) throw new ArgumentException("Overtime win points can't be lower than overtime lose points!");
             
            base.Create(item);
        }

        public override void Update(BeerpongTournament item)
        {
            if (item.PointsForOverTimeWin < item.PointsForOverTimeLose) throw new ArgumentException("Overtime win points can't be lower than overtime lose points!");

            base.Update(item);
        }
    }
}
