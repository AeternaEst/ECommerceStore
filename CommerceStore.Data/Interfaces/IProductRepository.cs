﻿using CommerceStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceStore.Data.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(); 
    }
}
