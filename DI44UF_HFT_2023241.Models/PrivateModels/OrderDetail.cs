using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace DI44UF_HFT_2023241.Models
{
    public class OrderDetail : IOrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; }

        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [Required]
        public int Quantity { get; set; }

        public OrderDetail()
        {
            
        }

        public OrderDetail(int orderItemId, int productId, int orderId)
        {
            OrderItemId = orderItemId;
            ProductId = productId;
            OrderId = orderId;
        }
    }
}
