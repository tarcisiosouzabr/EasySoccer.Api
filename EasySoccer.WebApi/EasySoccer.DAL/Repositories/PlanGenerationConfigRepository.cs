﻿using EasySoccer.DAL.Infra;
using EasySoccer.DAL.Infra.Repositories;
using EasySoccer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySoccer.DAL.Repositories
{
    public class PlanGenerationConfigRepository : RepositoryBase, IPlanGenerationConfigRepository
    {
        public PlanGenerationConfigRepository(IEasySoccerDbContext dbContext) : base(dbContext)
        {
        }

        public Task<PlanGenerationConfig> GetAsync(long id)
        {
            return _dbContext.PlanGenerationConfigQuery.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<PlanGenerationConfig>> GetAsync(long companyId, int page, int pageSize)
        {
            return _dbContext.PlanGenerationConfigQuery.Where(x => x.CompanyId == companyId).Skip((page - 1) * pageSize)
                .Take(pageSize).ToListAsync();
        }

        public Task<int> GetTotalAsync(long companyId)
        {
            return _dbContext.PlanGenerationConfigQuery.Where(x => x.CompanyId == companyId).CountAsync();
        }
    }
}