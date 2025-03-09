using BracketMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public interface IGroupLogic<T> where T : Group
    {
        void Validate(T item);
    }
}
