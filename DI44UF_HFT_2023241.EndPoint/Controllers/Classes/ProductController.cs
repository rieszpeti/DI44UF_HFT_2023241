using DI44UF_HFT_2023241.EndPoint.Controllers;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public class ProductController : GenericController<Product>, IGenericSpecialController<Product>
    {
        public ProductController(ILogicSpecial<Product> logic) : base(logic)
        {
        }

        [HttpGet]
        [Route("ReadByName")]
        public IEnumerable<Product> ReadByName(string name)
        {
            return ((ILogicSpecial<Product>)_logic).ReadByName(name);
        }
    }
}
