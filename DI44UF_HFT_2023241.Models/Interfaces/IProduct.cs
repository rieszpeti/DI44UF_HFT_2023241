using System.Collections.Generic;

namespace DI44UF_HFT_2023241.Models
{
    public interface IProduct
    {
        string Description { get; set; }
        int Price { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        int OrderItemId { get; set; }
        string Size { get; set; }
    }
}