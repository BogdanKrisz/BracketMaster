﻿using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public interface IAuthLogic
    {
        void Validate(Owner item);
    }
}
