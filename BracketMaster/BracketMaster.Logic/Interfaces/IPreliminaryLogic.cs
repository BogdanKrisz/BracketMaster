﻿using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public interface IPreliminaryLogic
    {
        void ExecutePreliminary(PreliminarySystem preliminary, Tournament tournament);
    }
}
