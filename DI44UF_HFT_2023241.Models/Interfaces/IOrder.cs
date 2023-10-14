using System;
using System.Collections.Generic;

namespace DI44UF_HFT_2023241.Models
{
    public interface IOrder
    {
        int CustomerId { get; set; }
        DateTime OrderDate { get; set; }
        int OrderId { get; set; }
        DateTime ShippingDate { get; set; }
    }
}