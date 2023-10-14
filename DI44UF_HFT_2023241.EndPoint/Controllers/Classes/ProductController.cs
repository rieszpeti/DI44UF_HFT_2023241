using DI44UF_HFT_2023241.EndPoint.Controllers;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public class ProductController : GenericController<IProduct>, IGenericSpecialController<IProduct>
    {
        public ProductController(ILogicSpecial<IProduct> logic) : base(logic)
        {
        }

        [HttpGet]
        [Route("ReadByName")]
        public IEnumerable<IProduct> ReadByName(string name)
        {
            return ((ILogicSpecial<IProduct>)_logic).ReadByName(name);
        }
    }
}
