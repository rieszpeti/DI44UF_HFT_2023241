using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;

namespace DI44UF_HFT_2023241.Models.Dto
{
    public class ProductDto
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
        public string Size { get; set; }

        [Required]
        public int OrderItemId { get; set; }

        [Required]
        public int Price { get; set; }

        public ProductDto(int id, string name, string description, string size)
        {
            Id = id;
            Name = name;
            Description = description;
            Size = size;
        }

        public override string ToString()
        {
            return  "ProductId: " + Id + " " +
                    "Name: " + Name + " " +
                    "Description: " + Description + " " +
                    "Size: " + Size + " " +
                    "OrderItemId: " + OrderItemId;
        }
    }
}
