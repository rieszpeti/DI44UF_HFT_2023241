using DI44UF_HFT_2023241.EndPoint.Controllers;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public class CustomerController : GenericController<Customer, CustomerDto>, IGenericSpecialController<Customer, CustomerDto>
    {
        public CustomerController(ILogger logger, ILogicSpecial<Customer> logic) : base(logger, logic)
        {
        }

        [NonAction]
        public override Customer ConvertDtoToModel(CustomerDto inp)
        {
            //if (inp is null)
            //{
            //    return null;
            //}
            return new Customer
                (
                    inp.CustomerId,
                    inp.Name,
                    inp.AddressId
                );
        }

        [NonAction]
        public override CustomerDto ConvertModelToDto(Customer inp)
        {
            //if (inp is null)
            //{
            //    return null;
            //}
            return new CustomerDto
                (
                    inp.CustomerId,
                    inp.Name,
                    inp.AddressId
                );
        }

        [HttpGet("name/{name}")]
        //[Route("{name}")]
        public IEnumerable<CustomerDto> ReadByName(string name)
        {
            var names = ((ILogicSpecial<Customer>)_logic).ReadByName(name).ToList();

            _logger.Information("Get {name}", name);

            return names.Select(x => ConvertModelToDto(x));
        }
    }
}
