using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Logic
{
    public class CustomerLogic : Logic<ICustomer>, ILogicSpecial<ICustomer>
    {
        public CustomerLogic(IRepositorySpecial<ICustomer> repo) : base(repo)
        {
        }

        public IQueryable<ICustomer> ReadByName(string name)
        {
            return ((IRepositorySpecial<ICustomer>)_repo).ReadByName(name);
        }
    }
}
