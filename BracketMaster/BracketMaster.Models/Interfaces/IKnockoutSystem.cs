﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public interface IKnockoutSystem
    {
        ICollection<Player> Players { get; set; }
        ICollection<Match> Matches { get; set; }
    }
}
