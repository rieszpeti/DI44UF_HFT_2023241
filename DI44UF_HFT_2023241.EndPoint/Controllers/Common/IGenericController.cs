using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public interface IGenericController<T, X> where T : class
    {
        void Create([FromBody] X value);
        void Delete(int id);
        void Put([FromBody] X value);
        X Read(int id);
        IEnumerable<X> ReadAll();
        
        T ConvertDtoToModel(X dto);
        X ConvertModelToDto(T model);
    }
}