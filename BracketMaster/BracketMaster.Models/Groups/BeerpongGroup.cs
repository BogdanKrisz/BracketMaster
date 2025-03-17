using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public class BeerpongGroup : Group
    {
        public BeerpongGroup()
        {
            Players = new HashSet<Player>(new HashSet<BeerpongPlayer>());
            Matches = new HashSet<Match>(new HashSet<BeerpongMatch>());
        }
    }
}
