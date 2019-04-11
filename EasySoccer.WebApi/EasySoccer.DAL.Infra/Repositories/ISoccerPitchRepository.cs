﻿using EasySoccer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasySoccer.DAL.Infra.Repositories
{
    public interface ISoccerPitchRepository
    {
        Task<long[]> GetAsync(int companyId);
        Task<List<SoccerPitch>> GetAsync(int page, int pageSize);
    }
}
