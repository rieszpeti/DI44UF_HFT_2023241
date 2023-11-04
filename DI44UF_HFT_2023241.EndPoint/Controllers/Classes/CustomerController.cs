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
    public class CustomerController : GenericController<Customer, CustomerDto>, IGenericController<Customer, CustomerDto>
    {
        public CustomerController(ICustomerLogic customerLogic) : base(customerLogic)
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
                    inp.UserName,
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
                    inp.UserName,
                    inp.AddressId
                );
        }
    }
}
