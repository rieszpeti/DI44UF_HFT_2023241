using DI44UF_HFT_2023241.EndPoint.Controllers;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Logic.Mapper;
using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public class OrderController : GenericController<Order, OrderDto>, IGenericController<Order, OrderDto>
    {
        public OrderController(ILogger logger, ILogic<Order> logic, IMapper<Order, OrderDto> orderMapper)
                               : base(logger, logic, orderMapper)
        {
        }
    }
}