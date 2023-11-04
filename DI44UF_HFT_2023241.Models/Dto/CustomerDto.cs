using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace DI44UF_HFT_2023241.Models.Dto
{
    public class CustomerDto : ICustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(240)]
        public string Name { get; set; }

        /// <summary>
        /// assume customer has only one address
        /// </summary>
        [Required]
        public int AddressId { get; set; }
        public AddressDto Address { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }



        public string Password { get; set; }

        public CustomerDto(int customerId, string name, int addressId)
        {
            CustomerId = customerId;
            Name = name;
            AddressId = addressId;
        }

        public override string ToString()
        {
            return  "CustomerId: " + CustomerId + " " +
                    "Name: " + Name + " " +
                    "AddressId: " + AddressId;
        }
    }
}
