using DI44UF_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Repository
{
    public class ActorRepository : Repository<Actor>, IRepository<Actor>
    {
        public ActorRepository(OrderDbContext ctx) : base(ctx)
        {
        }
    }
}
