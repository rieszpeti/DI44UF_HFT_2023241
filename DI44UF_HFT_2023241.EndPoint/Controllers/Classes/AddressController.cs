using DI44UF_HFT_2023241.EndPoint.Controllers;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public class AddressController : GenericController<IAddress>, IGenericSpecialController<IAddress>
    {
        public AddressController(ILogicSpecial<IAddress> logic) : base(logic)
        {
        }

        [HttpGet]
        [Route("ReadByName")]
        public IEnumerable<IAddress> ReadByName(string name)
        {
            return ((ILogicSpecial<IAddress>)_logic).ReadByName(name);
        }
    }
}