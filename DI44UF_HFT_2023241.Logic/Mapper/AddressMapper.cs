using DI44UF_HFT_2023241.Models.Dto;
using DI44UF_HFT_2023241.Models;

namespace DI44UF_HFT_2023241.Logic.Mapper
{
    public class AddressMapper : IMapper<Address, AddressDto>
    {
        public Address ConvertDtoToModel(AddressDto inp)
        {
            if (inp is null)
            {
                return null;
            }
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

        public AddressDto ConvertModelToDto(Address inp)
        {
            if (inp is null)
            {
                return null;
            }
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
    }
}
