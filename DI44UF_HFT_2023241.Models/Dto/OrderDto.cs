using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DI44UF_HFT_2023241.Models.Dto
{
    public class OrderDto : IOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public DateTime ShippingDate { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public OrderDto(int orderId, DateTime orderDate, DateTime shippingDate, int customerId)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            ShippingDate = shippingDate;
            CustomerId = customerId;
        }

        public override string ToString()
        {
            return  "OrderId: " + OrderId + " " +
                    "OrderDate: " + OrderDate + " " +
                    "ShippingDate: " + ShippingDate + " " +
                    "CustomerId: " + CustomerId;
        }
    }
}
