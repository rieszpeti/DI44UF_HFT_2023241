using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Logic
{
    public class AddressLogic : Logic<Address>, ILogic<Address>
    {
        public AddressLogic(IRepository<Address> repo) : base(repo)
        {
        }
    }
}
