using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public class BeerpongGroupLogic : GroupLogic<BeerpongGroup>, IGroupLogic<BeerpongGroup>
    {
        public BeerpongGroupLogic()
        {
            
        }

        public override void Validate(BeerpongGroup item)
        {
            base.Validate(item);
        }
    }
}
