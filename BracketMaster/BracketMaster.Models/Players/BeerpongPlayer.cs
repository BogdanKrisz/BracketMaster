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
    public class BeerpongPlayer : Player, IBeerpongPlayer
    {
        public override int Points 
        { 
            get
            {
                int result = 0;
                foreach (var match in HomeMatches)
                {
                    result += countMatchPoints(match as BeerpongMatch);
                }
                foreach (var match in AwayMatches)
                {
                    result += countMatchPoints(match as BeerpongMatch);
                }
                return result;
            } 
        }

        public int Cups
        {
            get
            {
                int result = 0;
                foreach (var match in HomeMatches)
                {
                    result += getMatchCups(match as BeerpongMatch);
                }
                foreach (var match in AwayMatches)
                {
                    result += getMatchCups(match as BeerpongMatch);
                }
                return result;
            }
        }

        public BeerpongPlayer(string name, int tournamentId) : base(name, tournamentId)
        {
            HomeMatches = new HashSet<Match>(new HashSet<BeerpongMatch>());
            AwayMatches = new HashSet<Match>(new HashSet<BeerpongMatch>());
        }

        int countMatchPoints(BeerpongMatch m)
        {
            BeerpongTournament t = this.Tournament as BeerpongTournament;
            if (!m.IsFinished)
            {
                // game not finished
                return 0;
            }
            else if (m.WinnerId != this.Id && m.IsOverTime)
            {
                // overtime lose
                return t.PointsForOverTimeLose;
            }
            else if (m.WinnerId != this.Id)
            {
                // lose
                return t.PointsForLose;
            }
            else if (m.WinnerId == this.Id && m.IsOverTime)
            {
                // overtime win
                return t.PointsForOverTimeWin;
            }
            else
            {
                // win
                return t.PointsForWin;
            }
        }

        int getMatchCups(BeerpongMatch m)
        {
            if (!m.IsFinished)
            {
                // game not finished
                return 0;
            }
            else if(m.WinnerId != this.Id)
            {
                // lost
                return m.CupDifference * -1;
            }
            else
            {
                // won
                return m.CupDifference;
            }
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
