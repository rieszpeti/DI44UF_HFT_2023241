using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Logic
{
    public class OrderLogic : Logic<Order>, ILogic<Order>
    {
        public OrderLogic(ILogger logger, IRepository<Order> repo) : base(logger, repo)
        {
        }
    }
}
