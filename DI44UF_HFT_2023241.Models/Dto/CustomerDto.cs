﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace DI44UF_HFT_2023241.Models.Dto
{
    public class CustomerDto
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
        //public AddressDto Address { get; set; }

        //public List<OrderDto> Orders { get; set; }

        public CustomerDto(int customerId, string name, int addressId)
        {
            CustomerId = customerId;
            UserName = name;
            AddressId = addressId;
        }

        public override string ToString()
        {
            return  "CustomerId: " + CustomerId + " " +
                    "Name: " + UserName + " " +
                    "AddressId: " + AddressId;
        }
    }
}
