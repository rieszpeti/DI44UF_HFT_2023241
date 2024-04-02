using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace DI44UF_HFT_2023241.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Street { get; set; }

        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

        public Address()
        {
            
        }

        public Address(int addressId, string postalCode, string city, string region, string country, string street)
        {
            AddressId = addressId;
            PostalCode = postalCode;
            City = city;
            Region = region;
            Country = country;
            Street = street;
        }

        public override string ToString()   
        {
            return "Address: " + AddressId + " " +
                    "PostalCode: " + PostalCode + " " +
                    "City: " + City + " " +
                    "Region: " + Region + " " +
                    "Country: " + Country + " " +
                    "Street: " + Street;
        }
    }
}
