using EvaluationSystem.Core.Domain.Users.Entities;
using EvaluationSystem.Core.Domain.Users.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Infra.DAL.SQL.Users.Repositories
{
    public class EfUserRepository : IUserRepository
    {
        private readonly EvaluationSystemDbContext dbContext;

        public EfUserRepository(EvaluationSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User GetById(int userId)
        {
            return dbContext.Users.AsNoTracking()
                .Include(x=>x.College)
                .Where(x => x.Id == userId)
                .FirstOrDefault();
        }

        public User GetByUserName(string userName)
        {
            return dbContext.Users.AsNoTracking()
                .Include(x => x.College)
                .Where(x => x.UserName == userName)
                .FirstOrDefault();
        }

        public UserAccessToken GetUserAccessToken(int userId)
        {
            return dbContext.UserAccessTokens.AsNoTracking()
                .Where(x => x.UserId == userId)
                .FirstOrDefault();
        }

        public UserAccessToken GetUserAccessToken(string accessToken)
        {
            return dbContext.UserAccessTokens.AsNoTracking().Where(x => x.Token == accessToken).FirstOrDefault();
        }

        public void StoreAccessToken(int userId, string token)
        {
            dbContext.UserAccessTokens.Add(new UserAccessToken { Token = token, UserId = userId });
        }
    }
}
