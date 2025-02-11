﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public class Player : Entity
    {
        public string Name { get; set; }

        [NotMapped]
        public virtual Tournament Tournament { get; set; }
        public int TournamentId { get; set; }

        [NotMapped]
        public virtual ICollection<Match> Matches { get; set; }

        public Player()
        {
            Matches = new HashSet<Match>();
        }
    }
}
