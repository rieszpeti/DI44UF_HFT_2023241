using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Logic
{
    public class OrderDetailLogic : Logic<IOrderDetail>, ILogic<IOrderDetail>
    {
        public OrderDetailLogic(IRepository<IOrderDetail> repo) : base(repo)
        {
        }
    }
}
