using DI44UF_HFT_2023241.EndPoint.Controllers;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public class ProductController : GenericController<IProduct>, IGenericSpecialController<IProduct>
    {
        public ProductController(ILogicSpecial<IProduct> logic) : base(logic)
        {
        }

        public IQueryable<IProduct> ReadByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
