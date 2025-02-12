using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public interface IBeerpongTournament
    {
        int PointsForOverTimeWin { get; set; }
        int PointsForOverTimeLose { get; set; }
    }
}
