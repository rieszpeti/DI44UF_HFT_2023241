using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Logic.Mapper;
using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DI44UF_HFT_2023241.EndPoint
{
    public class StatisticsController : ControllerBase
    {
        private readonly ICustomerLogic _logic;

        private readonly IMapper<Order, OrderDto> _orderMapper;
        private readonly IMapper<Address, AddressDto> _addressMapper;

        public StatisticsController(ICustomerLogic logic, IMapper<Order, OrderDto> orderMapper)
        {
            _logic = logic;
            _orderMapper = orderMapper;
        }

        [HttpGet("statistics/Avg/{customerId}")]
        public double GetAvgPriceOfAllOrders(int customerId)
        {
            return _logic.GetAvgPriceOfAllOrders(customerId);
        }

        [HttpGet("statistics/LinReg/{customerId}")]
        public string LinearRegressionFromCustomerData(int customerId)
        {
            return _logic.LinearRegressionFromCustomerData(customerId);
        }

        [HttpGet("statistics/orderHistory/{customerId}")]
        public IEnumerable<OrderDto> GetOrderHistory(int customerId)
        {
            var models = _logic.GetOrderHistory(customerId);

            return models.Select(x => _orderMapper.ConvertModelToDto(x));
        }

        [HttpGet("statistics/address/{customerId}")]
        public AddressDto GetAddress(int customerId)
        {
            var model = _logic.GetAddress(customerId);

            return _addressMapper.ConvertModelToDto(model);
        }

        [HttpGet("statistics/ordersBetweenDate/{customerId}/{dateStart}/{dateEnd}")]
        public IEnumerable<OrderDto> GetOrdersBetweenDates(int customerId, DateTime dateStart, DateTime dateEnd)
        {
            var models = _logic.GetOrdersBetweenDates(customerId, dateStart, dateEnd);

            return models.Select(x => _orderMapper.ConvertModelToDto(x));
        }
    }
}
