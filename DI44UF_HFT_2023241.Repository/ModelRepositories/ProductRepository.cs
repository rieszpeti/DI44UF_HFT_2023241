using DI44UF_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Repository.ModelRepositories
{
    public class ProductRepository : Repository<Product>, IRepositorySpecial<Product>
    {
        public ProductRepository(OrderDbContext ctx) : base(ctx)
        {
        }

        public IQueryable<Product> ReadByName(string name)
        {
            return from ad in _ctx.Products
                   where ad.Name == name
                   select ad;
        }
    }
}
