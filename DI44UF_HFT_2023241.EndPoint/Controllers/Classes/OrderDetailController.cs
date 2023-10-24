﻿using DI44UF_HFT_2023241.EndPoint.Controllers;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public class OrderDetailController : GenericController<OrderDetail, OrderDetailDto>, IGenericController<OrderDetail, OrderDetailDto>
    {
        public OrderDetailController(ILogic<OrderDetail> logic) : base(logic)
        {
        }

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