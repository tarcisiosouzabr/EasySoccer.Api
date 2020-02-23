﻿using EasySoccer.DAL.Infra;
using EasySoccer.DAL.Infra.Repositories;
using EasySoccer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EasySoccer.DAL.Repositories
{
    public class CompanyUserRepository : RepositoryBase, ICompanyUserRepository
    {
        public CompanyUserRepository(IEasySoccerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<CompanyUser> GetAsync(long userId)
        {
            return await _dbContext.CompanyUserQuery.Where(x => x.Id == userId).FirstOrDefaultAsync();
        }

        public Task<CompanyUser> LoginAsync(string email, string password)
        {
            return _dbContext.CompanyUserQuery.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
        }
    }
}
