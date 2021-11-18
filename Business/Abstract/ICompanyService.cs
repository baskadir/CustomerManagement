﻿using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllAsync();
    }
}
