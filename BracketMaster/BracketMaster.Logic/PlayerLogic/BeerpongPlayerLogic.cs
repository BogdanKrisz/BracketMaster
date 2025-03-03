using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public class BeerpongPlayerLogic : PlayerLogic<BeerpongPlayer>, IPlayerLogic<BeerpongPlayer>
    {
        public BeerpongPlayerLogic()
        {
        }
    }
}
