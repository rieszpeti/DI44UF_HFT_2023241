using System.Collections.Generic;
using System.Linq;

namespace DI44UF_HFT_2023241.Logic
{
    public interface ILogic<T> where T : class
    {
        void Create(T item);
        void Delete(int id);
        T Read(int id);
        IEnumerable<T> ReadAll();
        void Update(T item);
    }
}