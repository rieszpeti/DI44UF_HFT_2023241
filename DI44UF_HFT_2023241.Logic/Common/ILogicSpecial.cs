using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Logic
{
    public interface ILogicSpecial<T> : ILogic<T> where T : class
    {
        IQueryable<T> ReadByName(string name);
    }
}
