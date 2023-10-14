using System.Collections.Generic;

namespace DI44UF_HFT_2023241.Models
{
    public interface ICustomer
    {
        int AddressId { get; set; }
        int CustomerId { get; set; }
        string Name { get; set; }
    }
}