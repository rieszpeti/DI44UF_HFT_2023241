using System;
using System.Collections.Generic;
using System.Numerics;

namespace DI44UF_HFT_2023241.Models
{
    /// <summary>
    /// products
    /// </summary>
    public class Product : IProduct
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string Size { get; set; }

        public int WebsiteId { get; init; }
        public virtual WebSite Website { get; set; }

        public Product()
        {
            
        }

        public Product(int id, string name, string description, string size)
        {
            Id = id;
            Name = name;
            Description = description;
            Size = size;
        }

        public Product(int id, string name, string description, string size, int websiteId)
        {
            Id = id;
            Name = name;
            Description = description;
            Size = size;
            WebsiteId = websiteId;
        }
    }
}
