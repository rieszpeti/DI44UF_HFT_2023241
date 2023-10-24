using DI44UF_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Repository.ModelRepositories
{
    public class CustomerRepository : Repository<Customer>, IRepositoryLogin<Customer>
    {
        public CustomerRepository(OrderDbContext ctx) : base(ctx)
        {
        }

        public bool CheckLogin(string name, string password)
        {
            return _ctx.Set<Customer>().Any(c =>
                c.Name == name &&
                c.Password == password
            );
        }

        public IQueryable<Customer> ReadByName(string name)
        {
            return from c in _ctx.Customers
                   where c.Name == name
                   select c;
        }
    }
}
