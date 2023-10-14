using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}
