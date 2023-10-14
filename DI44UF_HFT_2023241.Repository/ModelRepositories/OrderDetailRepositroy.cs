using DI44UF_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Repository.ModelRepositories
{
    public class OrderDetailRepository : Repository<IOrderDetail>, IRepository<IOrderDetail>
    {
        public OrderDetailRepository(OrderDbContext ctx) : base(ctx)
        {
        }
    }
}
