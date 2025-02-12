using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    public interface IBeerpongMatch
    {
        int CupDifference { get; }
        bool IsOverTime { get; }
    }
}
