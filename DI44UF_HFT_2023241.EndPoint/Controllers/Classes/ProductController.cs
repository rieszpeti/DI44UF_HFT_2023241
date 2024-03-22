﻿using DI44UF_HFT_2023241.EndPoint.Controllers;
using DI44UF_HFT_2023241.EndPoint.Services;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Logic.Mapper;
using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public class ProductController : GenericController<Product, ProductDto>, IGenericController<Product, ProductDto>
    {
        public ProductController(ILogger logger, ILogic<Product> logic, IMapper<Product, ProductDto> productMapper, IHubContext<SignalRHub> hub)
                                : base(logger, logic, productMapper, hub)
        {
        }
    }
}
