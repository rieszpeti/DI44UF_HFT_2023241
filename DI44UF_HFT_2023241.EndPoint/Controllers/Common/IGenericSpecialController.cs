using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public interface IGenericSpecialController<T, X> : IGenericController<T, X> where T : class
    {
        [HttpGet]
        IEnumerable<X> ReadByName(string name);
    }
}
