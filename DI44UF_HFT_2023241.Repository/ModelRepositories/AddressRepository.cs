using DI44UF_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Repository.ModelRepositories
{
    public class AddressRepository : Repository<Address>, IRepositorySpecial<Address>
    {
        public AddressRepository(OrderDbContext ctx) : base(ctx)
        {
        }

        public IQueryable<Address> ReadByName(string street)
        {
            return from ad in _ctx.Addresses
                   where ad.Street == street
                   select ad;
        }
    }
}
