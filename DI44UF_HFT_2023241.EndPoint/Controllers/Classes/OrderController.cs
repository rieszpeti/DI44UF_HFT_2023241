using DI44UF_HFT_2023241.EndPoint.Controllers;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public class OrderController : GenericController<Order, OrderDto>, IGenericController<Order, OrderDto>
    {
        public OrderController(ILogic<Order> logic) : base(logic)
        {
        }

        public override Order ConvertDtoToModel(OrderDto inp)
        {
            return new Order
                (
                    inp.OrderId,
                    inp.OrderDate,
                    inp.ShippingDate,
                    inp.CustomerId
                );
        }

        public override OrderDto ConvertModelToDto(Order inp)
        {
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