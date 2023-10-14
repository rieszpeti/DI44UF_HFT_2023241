using DI44UF_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Repository.ModelRepositories
{
    public class CustomerRepository : Repository<ICustomer>, IRepositorySpecial<ICustomer>
    {
        public CustomerRepository(OrderDbContext ctx) : base(ctx)
        {
        }

        public IQueryable<ICustomer> ReadByName(string name)
        {
            return from c in _ctx.Customers
                   where c.Name == name
                   select c;
        }
    }
}
