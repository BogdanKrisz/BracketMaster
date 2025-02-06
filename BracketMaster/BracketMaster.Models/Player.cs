using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public class Player : Entity
    {
        public string Name { get; set; }
        public Tournament Tournament { get; set; }
    }
}
