using System;

namespace DI44UF_HFT_2023241.Models
{
    /// <summary>
    /// Crawled products
    /// </summary>
    public class Product
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string Size { get; set; }
    }
}
