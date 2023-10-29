using DI44UF_HFT_2023241.EndPoint.Controllers;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public class OrderDetailController : GenericController<OrderDetail, OrderDetailDto>, IGenericController<OrderDetail, OrderDetailDto>
    {
        public OrderDetailController(ILogger logger, ILogic<OrderDetail> logic) : base(logger, logic)
        {
        }

        [NonAction]
        public override OrderDetail ConvertDtoToModel(OrderDetailDto inp)
        {
            return new OrderDetail
                (
                    inp.OrderItemId,
                    inp.ProductId,
                    inp.OrderId,
                    inp.Quantity
                );
        }

        [NonAction]
        public override OrderDetailDto ConvertModelToDto(OrderDetail inp)
        {
            return new OrderDetailDto
                (
                    inp.OrderItemId,
                    inp.ProductId,
                    inp.OrderId,
                    inp.Quantity
                );
        }
    }
}
