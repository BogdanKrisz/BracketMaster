using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public interface IBaseLogic<T>
    {
        void Create(T item);
        T Read(int id);
        IQueryable<T> ReadAll();
        void Update(T item);
        void Delete(int id);
    }
}
