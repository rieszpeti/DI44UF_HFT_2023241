using DI44UF_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Repository.ModelRepositories
{
    public class ProductRepository : Repository<IProduct>, IRepositorySpecial<IProduct>
    {
        public ProductRepository(OrderDbContext ctx) : base(ctx)
        {
        }

        public IQueryable<IProduct> ReadByName(string name)
        {
            return from p in _ctx.Products
                   where p.Name == name
                   select p;
        }
    }
}
