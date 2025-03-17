using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public interface IBeerpongTournament
    {
        BeerpongOvertimeType? BeerpongOvertimeType { get; set; }
        int BeerpongOvertimeTypeId { get; set; }
        int? PointsForOverTimeWin { get; set; }
        int? PointsForOverTimeLose { get; set; }
    }
}
