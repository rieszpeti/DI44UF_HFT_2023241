using DI44UF_HFT_2023241.EndPoint.Controllers;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Logic.Mapper;
using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public class OrderDetailController : GenericController<OrderDetail, OrderDetailDto>, IGenericController<OrderDetail, OrderDetailDto>
    {
        public OrderDetailController(ILogic<OrderDetail> logic, IMapper<OrderDetail, OrderDetailDto> orderDetailMapper) : base(logic, orderDetailMapper)
        {
        }
    }
}
