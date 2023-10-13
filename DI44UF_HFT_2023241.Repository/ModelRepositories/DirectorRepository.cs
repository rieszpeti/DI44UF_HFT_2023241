using DI44UF_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Repository
{
    public class DirectorRepository : Repository<Director>, IRepository<Director>
    {
        public DirectorRepository(OrderDbContext ctx) : base(ctx)
        {
        }
    }
}
