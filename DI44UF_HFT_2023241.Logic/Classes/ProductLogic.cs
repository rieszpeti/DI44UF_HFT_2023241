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
    public class ProductLogic : Logic<Product>, ILogicSpecial<Product>
    {
        public ProductLogic(ILogger logger, IRepositorySpecial<Product> repo) : base(logger, repo)
        {
        }

        public IQueryable<Product> ReadByName(string name)
        {
            return ((IRepositorySpecial<Product>)_repo).ReadByName(name);
        }
    }
}
