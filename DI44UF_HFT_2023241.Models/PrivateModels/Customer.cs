using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DI44UF_HFT_2023241.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(240)]
        public string Name { get; set; }

        [Required]
        public int Address { get; set; }
        public ICollection<Order> Orders { get; } = new List<Order>();

        public Customer()
        {
            
        }
    }
}
