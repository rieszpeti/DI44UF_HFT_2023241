using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Logic
{
    public class ProductLogic : Logic<Product>, ILogicSpecial<Product>
    {
        public ProductLogic(IRepositorySpecial<Product> repo) : base(repo)
        {
        }

        public IQueryable<Product> ReadByName(string name)
        {
            return ((IRepositorySpecial<Product>)_repo).ReadByName(name);
        }
    }
}
