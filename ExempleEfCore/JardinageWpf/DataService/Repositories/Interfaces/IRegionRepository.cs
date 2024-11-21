﻿using JardinageWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardinageWpf.DataService.Repositories.Interfaces
{
    public interface IRegionRepository
    {
        List<Region> GetAll();

        Task<List<Region>> GetAllAsync();
    }
}