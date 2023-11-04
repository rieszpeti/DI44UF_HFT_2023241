using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Logic.Mapper
{
    public class CustomerMapper : IMapper<Customer, CustomerDto>
    {
        public Customer ConvertDtoToModel(CustomerDto inp)
        {
            if (inp is null)
            {
                return null;
            }
            return new Customer
                (
                    inp.CustomerId,
                    inp.UserName,
                    inp.AddressId
                );
        }

        public CustomerDto ConvertModelToDto(Customer inp)
        {
            if (inp is null)
            {
                return null;
            }
            return new CustomerDto
                (
                    inp.CustomerId,
                    inp.UserName,
                    inp.AddressId
                );
        }
    }
}
