using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public interface IGenericController<Entity, Dto> where Entity : class where Dto : class
    {
        IActionResult Create([FromBody] Dto value);
        IActionResult Delete(int id);
        IActionResult Put([FromBody] Dto value);
        IActionResult Read(int id);
        IActionResult ReadAll();
    }
}


//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;

//namespace DI44UF_HFT_2023241.EndPoint.Controllers
//{
//    public interface IGenericController<T, X> where T : class
//    {
//        void Create([FromBody] X value);
//        void Delete(int id);
//        void Put([FromBody] X value);
//        X Read(int id);
//        IEnumerable<X> ReadAll();
//    }
//}