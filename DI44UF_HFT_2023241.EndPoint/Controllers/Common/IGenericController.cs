using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public interface IGenericController<T> where T : class
    {
        void Create([FromBody] T value);
        void Delete(int id);
        void Put([FromBody] T value);
        T Read(int id);
        IEnumerable<T> ReadAll();
    }
}