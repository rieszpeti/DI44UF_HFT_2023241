using DI44UF_HFT_2023241.EndPoint.Controllers;
using DI44UF_HFT_2023241.Logic;
using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace DI44UF_HFT_2023241.EndPoint.Controllers
{
    public class ProductController : GenericController<Product, ProductDto>, IGenericSpecialController<Product, ProductDto>
    {
        public ProductController(ILogger logger, ILogicSpecial<Product> logic) : base(logger, logic)
        {
        }

        [NonAction]
        public override Product ConvertDtoToModel(ProductDto inp)
        {
            return new Product
                (
                    inp.Id,
                    inp.Name,
                    inp.Description,
                    inp.Size,
                    inp.OrderItemId
                );
        }

        [NonAction]
        public override ProductDto ConvertModelToDto(Product inp)
        {
            return new ProductDto
                (
                    inp.Id,
                    inp.Name,
                    inp.Description,
                    inp.Size,
                    inp.OrderItemId
                );
        }

        [HttpGet("name/{name}")]
        //[Route("{name}")]
        public IEnumerable<ProductDto> ReadByName(string name)
        {
            var names = ((ILogicSpecial<Product>)_logic).ReadByName(name).ToList();
            return names.Select(x => ConvertModelToDto(x));
        }
    }
}
