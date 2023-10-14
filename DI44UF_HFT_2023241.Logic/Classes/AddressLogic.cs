﻿using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Logic
{
    public class AddressLogic : Logic<Address>, ILogicSpecial<Address>
    {
        public AddressLogic(IRepositorySpecial<Address> repo) : base(repo)
        {
        }

        public IQueryable<Address> ReadByName(string name)
        {
            return ((IRepositorySpecial<Address>)_repo).ReadByName(name);
        }
    }
}
