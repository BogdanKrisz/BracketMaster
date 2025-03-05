using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public class BeerpongTournamentPlayerLogic : TournamentPlayerLogic<BeerpongTournamentPlayer>, ITournamentPlayerLogic<BeerpongTournamentPlayer>
    {
        public BeerpongTournamentPlayerLogic()
        {

        }

        public override void Validate(BeerpongTournamentPlayer item)
        {
            base.Validate(item);
        }
    }
}
