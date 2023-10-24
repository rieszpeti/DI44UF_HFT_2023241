using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Logic
{
    public class CustomerLogic : Logic<Customer>, ILogicLogin<Customer>
    {
        public CustomerLogic(IRepositoryLogin<Customer> repo) : base(repo)
        {
        }

        public bool CheckLogin(string name, string password)
        {
            return ((IRepositoryLogin<Customer>)_repo).CheckLogin(name, password);
        }

        public IQueryable<Customer> ReadByName(string name)
        {
            return ((IRepositorySpecial<Customer>)_repo).ReadByName(name);
        }
    }
}
