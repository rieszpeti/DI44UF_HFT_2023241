using DI44UF_HFT_2023241.Models.Dto;
using DI44UF_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Logic.Mapper
{
    public class ProductMapper : IMapper<Product, ProductDto>
    {
        public Product ConvertDtoToModel(ProductDto inp)
        {
            if (inp is null)
            {
                return null;
            }
            return new Product
                (
                    inp.Id,
                    inp.Name,
                    inp.Description,
                    inp.Size,
                    inp.OrderItemId,
                    inp.Price
                );
        }

        public ProductDto ConvertModelToDto(Product inp)
        {
            if (inp is null)
            {
                return null;
            }
            return new ProductDto
                (
                    inp.ProductId,
                    inp.Name,
                    inp.Description,
                    inp.Size,
                    inp.OrderItemId,
                    inp.Price
                );
        }
    }
}
