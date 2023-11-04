using DI44UF_HFT_2023241.EndPoint.Controllers;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public class AddressController : GenericController<Address, AddressDto>, IGenericController<Address, AddressDto>
    {
        public AddressController(ILogic<Address> logic) : base(logic)
        {
        }

        [NonAction]
        public override Address ConvertDtoToModel(AddressDto inp)
        {
           return new Address
                (
                    inp.AddressId,
                    inp.PostalCode,
                    inp.City,
                    inp.Region,
                    inp.Country,
                    inp.Street
                );
        }

        [NonAction]
        public override AddressDto ConvertModelToDto(Address inp)
        {
            return new AddressDto
                 (
                     inp.AddressId,
                     inp.PostalCode,
                     inp.City,
                     inp.Region,
                     inp.Country,
                     inp.Street
                 );
        }

        //[HttpGet("name/{name}")]
        //public IEnumerable<Address> ReadByName(string name)
        //{
        //    return ((ILogicSpecial<Address>)_logic).ReadByName(name).ToList();
        //}
    }
}