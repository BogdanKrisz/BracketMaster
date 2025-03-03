﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public abstract class Tournament : Entity, ITournament
    {
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Player> Players { get; set; }

        [NotMapped]
        public virtual ICollection<Match> Matches { get; set; }

        [NotMapped]
        public abstract ICollection<Player> Ranking { get; }

        [NotMapped]
        public virtual PreliminarySystem PreliminarySystem { get; set; }
        public int PreliminarySystemId { get; set; }
 
        [NotMapped]
        public virtual KnockoutSystem KnockoutSystem { get; set; }
        public int KnockoutSystemId { get; set; }

        public int PlayersToElimination { get; set; }

        public int PointsForWin { get; set; }
        public int PointsForLose { get; set; }

        public Tournament()
        {
            Players = new HashSet<Player>();
            Matches = new HashSet<Match>();
        }
    }
}
