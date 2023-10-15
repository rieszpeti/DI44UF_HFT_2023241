using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DI44UF_HFT_2023241.Models
{
    public class Product : IProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(240)]
        public string Name { get; set; }

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

        public Product(int id, string name, string description, string size, int orderItemId)
        {
            Id = id;
            Name = name;
            Description = description;
            Size = size;
            OrderItemId = orderItemId;
        }

        public override string ToString()
        {
            return "ProductId: " + Id + " " +
                    "Name: " + Name + " " +
                    "Description: " + Description + " " +
                    "Size: " + Size + " " +
                    "OrderItemId: " + OrderItemId;
        }
    }
}
