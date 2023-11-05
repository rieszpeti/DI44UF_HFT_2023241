using DI44UF_HFT_2023241.Models.Dto;
using DI44UF_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Logic.Mapper
{
    public class OrderDetailMapper : IMapper<OrderDetail, OrderDetailDto>
    {
        public OrderDetail ConvertDtoToModel(OrderDetailDto inp)
        {
            if (inp is null)
            {
                return null;
            }
            return new OrderDetail
                (
                    inp.OrderItemId,
                    inp.ProductId,
                    inp.OrderId,
                    inp.Quantity
                );
        }

        public OrderDetailDto ConvertModelToDto(OrderDetail inp)
        {
            if (inp is null)
            {
                return null;
            }
            return new OrderDetailDto
                (
                    inp.OrderDetailId,
                    inp.ProductId,
                    inp.OrderId,
                    inp.Quantity
                );
        }
    }
}
