﻿using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public abstract class PlayerLogic<T> : IPlayerLogic<T> where T : Player
    {
        protected PlayerLogic()
        {
            
        }

        public virtual void Validate(T item)
        {
            throw new NotImplementedException();
        }
    }
}
