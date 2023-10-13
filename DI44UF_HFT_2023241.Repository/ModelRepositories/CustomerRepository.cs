using DI44UF_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Repository.ModelRepositories
{
    public class CustomerRepository : Repository<Customer>, IRepositorySpecial<Customer>
    {
        public CustomerRepository(OrderDbContext ctx) : base(ctx)
        {
        }

        public IQueryable<Customer> ReadByName(string name)
        {
            return from ad in _ctx.Customers
                   where ad.Name == name
                   select ad;
        }
    }
}
