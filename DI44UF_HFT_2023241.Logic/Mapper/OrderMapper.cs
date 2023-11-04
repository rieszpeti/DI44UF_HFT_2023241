using DI44UF_HFT_2023241.Models.Dto;
using DI44UF_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Logic.Mapper
{
    public class OrderMapper : IMapper<Order, OrderDto>
    {
        public Order ConvertDtoToModel(OrderDto inp)
        {
            if (inp is null)
            {
                return null;
            }
            return new Order
                (
                    inp.OrderId,
                    inp.OrderDate,
                    inp.ShippingDate,
                    inp.CustomerId
                );
        }

        public OrderDto ConvertModelToDto(Order inp)
        {
            if (inp is null)
            {
                return null;
            }
            return new OrderDto
                (
                    inp.OrderId,
                    inp.OrderDate,
                    inp.ShippingDate,
                    inp.CustomerId
                );
        }
    }
}
