using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public class BeerpongMatchLogic : MatchLogic<BeerpongMatch, BeerpongPlayer>, IMatchLogic<BeerpongMatch, BeerpongPlayer>
    {
        public BeerpongMatchLogic()
        {

        }

        public override void Validate(BeerpongMatch item)
        {
            base.Validate(item);
        }



        // átkéne dobni logicba
        public override int CountMatchPoints(BeerpongMatch match, BeerpongPlayer player)
        {
            BeerpongTournament t = match.Tournament as BeerpongTournament;
            if (!match.IsFinished)
            {
                // game not finished
                return 0;
            }
            else if (t.PointsForOverTimeWin != null && match.IsOverTime && match.WinnerId == player.Id)
            {
                // OT Win
                return (int)t.PointsForOverTimeWin;
            }
            else if (t.PointsForOverTimeLose != null && match.IsOverTime && match.WinnerId != player.Id)
            {
                // OT Lose
                return (int)t.PointsForOverTimeLose;
            }
            else if (match.WinnerId != player.Id)
            {
                // lose
                return t.PointsForLose;
            }
            else
            {
                // win
                return t.PointsForWin;
            }

        }

        // átkéne dobni logicba
        public int CountMatchCups(BeerpongMatch match, BeerpongPlayer player)
        {
            BeerpongTournament t = match.Tournament as BeerpongTournament;
            var otType = t.BeerpongOvertimeType.Name.ToLower();

            if (!match.IsFinished || (otType == "bpbl" && match.IsOverTime))
            {
                // game not finished OR bpbl overtime type
                return 0;
            }
            else if (match.WinnerId == player.Id && (!match.IsOverTime || (otType == "none" || otType == "basic" || (otType == "esobp" && match.HomeScore < 16 && match.AwayScore < 16))))
            {
                // win with basic cup difference
                return match.CupDifference;
            }
            else if (match.WinnerId != player.Id && (!match.IsOverTime || (otType == "none" || otType == "basic" || (otType == "esobp" && match.HomeScore < 16 && match.AwayScore < 16))))
            {
                // lose with basic cup difference
                return match.CupDifference * -1;
            }
            else if (match.WinnerId == player.Id)
            {
                // win with ESOBP cup difference
                return 1;
            }
            else
            {
                // lose with ESOBP cup difference
                return -1;
            }
        }

        public override BeerpongPlayer AddPointsToPlayer(BeerpongMatch match, BeerpongPlayer player)
        {
            player.Points += CountMatchPoints(match, player);
            player.Cups += CountMatchCups(match, player);  
            return player;
        }
    }
}
