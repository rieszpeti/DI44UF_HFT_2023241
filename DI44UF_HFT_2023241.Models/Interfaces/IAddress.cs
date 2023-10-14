using System.Collections.Generic;

namespace DI44UF_HFT_2023241.Models
{
    public interface IAddress
    {
        int AddressId { get; set; }
        string City { get; set; }
        string Country { get; set; }
        string PostalCode { get; set; }
        string Region { get; set; }
        string Street { get; set; }
    }
}