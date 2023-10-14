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
    public class AddressLogic : Logic<IAddress>, ILogicSpecial<IAddress>
    {
        public AddressLogic(IRepositorySpecial<IAddress> repo) : base(repo)
        {
        }

        public IQueryable<IAddress> ReadByName(string name)
        {
            return ((IRepositorySpecial<IAddress>)_repo).ReadByName(name);
        }
    }
}