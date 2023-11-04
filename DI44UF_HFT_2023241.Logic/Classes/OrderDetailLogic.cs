using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Repository;
using Serilog;

namespace DI44UF_HFT_2023241.Logic
{
    public class OrderDetailLogic : Logic<OrderDetail>, ILogic<OrderDetail>
    {
        public OrderDetailLogic(ILogger logger, IRepository<OrderDetail> repo) : base(logger, repo)
        {
        }
    }
}
