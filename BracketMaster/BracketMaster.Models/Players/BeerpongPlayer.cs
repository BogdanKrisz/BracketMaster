using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    [Table("Beerpong_Players")]
    public class BeerpongPlayer : Player, IBeerpongPlayer
    {
        public int Cups { get; set; } = 0;

        public BeerpongPlayer()
        {
            HomeMatches = new HashSet<Match>(new HashSet<BeerpongMatch>());
            AwayMatches = new HashSet<Match>(new HashSet<BeerpongMatch>());
        }

        public override int CompareTo(Player? other)
        {
            if(other == null) return 1;

            BeerpongPlayer otherPlayer = other as BeerpongPlayer;

            if(this.Points != otherPlayer.Points)
                return otherPlayer.Points.CompareTo(this.Points);

            return otherPlayer.Cups.CompareTo(this.Cups);
        }
    }
}
