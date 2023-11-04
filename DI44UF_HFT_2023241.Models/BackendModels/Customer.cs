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
        public string UserName { get; set; }

        /// <summary>
        /// assume customer has only one address
        /// </summary>
        [Required]
        public int AddressId { get; set; }
        [Required]
        public virtual Address Address { get; set; }

        public virtual ICollection<Order> Orders { get; } = new List<Order>();
        
        public Customer()
        {
            
        }

        public Customer(int customerId, string name, int addressId)
        {
            CustomerId = customerId;
            UserName = name;
            AddressId = addressId;
        }
        public override string ToString()
        {
            return "CustomerId: " + CustomerId + " " +
                    "Name: " + UserName + " " +
                    "AddressId: " + AddressId;
        }
    }
}
