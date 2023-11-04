﻿using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Logic
{
    public class ProductLogic : Logic<Product>, ILogic<Product>
    {
        public ProductLogic(IRepository<Product> repo) : base(repo)
        {
        }
    }
}
