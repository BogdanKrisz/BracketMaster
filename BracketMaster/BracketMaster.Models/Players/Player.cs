﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public abstract class Player : Entity, IPlayer
    {
        public required string Name { get; set; } = string.Empty;

        public int Points { get; set; } = 0;

        [NotMapped]
        public virtual Tournament? Tournament { get; set; }
        public required int TournamentId { get; set; }

        [NotMapped]
        public virtual Group? Group { get; set; }
        public int? GroupId { get; set; }

        [NotMapped]
        public virtual ICollection<Match>? HomeMatches { get; set; }

        [NotMapped]
        public virtual ICollection<Match>? AwayMatches { get; set; }

        [NotMapped]
        public int NumOfPlayedGames => HomeMatches.Count + AwayMatches.Count; 

        [NotMapped]
        public ICollection<Player>? PreviousOpponents 
        { 
            get 
            { 
                ICollection<Player> opponents = new List<Player>();

                if (HomeMatches != null)
                    foreach (Match match in HomeMatches)
                        opponents.Add(match.Away);

                if (AwayMatches != null)
                    foreach (Match match in AwayMatches)
                        opponents.Add(match.Home);

                return opponents;
            } 
        }

        public abstract int CompareTo(Player? other);
    }
}
