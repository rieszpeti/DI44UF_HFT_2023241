using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace DI44UF_HFT_2023241.Models.Dto
{
    public class OrderDetailDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public OrderDetailDto(int orderItemId, int productId, int orderId, int quantity)
        {
            OrderItemId = orderItemId;
            ProductId = productId;
            OrderId = orderId;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return  "OrderItemId: " + OrderItemId + " " +
                    "ProductId: " + ProductId + " " +
                    "OrderId: " + OrderId + " " +
                    "Quantity: " + Quantity;
        }
    }
}
