using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public class BeerpongTournamentLogic : TournamentLogic<BeerpongTournament>, ITournamentLogic<BeerpongTournament>
    {
        public BeerpongTournamentLogic()
        {

        }

        public override void Validate(BeerpongTournament item)
        {
            base.Validate(item);
        }
    }
}
