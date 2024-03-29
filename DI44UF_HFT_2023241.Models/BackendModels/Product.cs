﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DI44UF_HFT_2023241.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        [StringLength(240)]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Size { get; set; }

        [Required]
        public int OrderItemId { get; set; }
        [Required]
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public Product()
        {
            
        }

        public Product(int id, string name, string description, string size, int orderItemId, int price)
        {
            ProductId = id;
            Name = name;
            Description = description;
            Size = size;
            OrderItemId = orderItemId;
            Price = price;
        }

        public override string ToString()
        {
            return "ProductId: " + ProductId + " " +
                    "Name: " + Name + " " +
                    "Description: " + Description + " " +
                    "Size: " + Size + " " +
                    "OrderItemId: " + OrderItemId + " " +
                    "Price:" + Price;
        }
    }
}
