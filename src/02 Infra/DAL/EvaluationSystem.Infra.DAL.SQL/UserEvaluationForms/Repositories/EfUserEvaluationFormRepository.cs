using EvaluationSystem.Core.Domain.UserEvaluationForms.Entities;
using EvaluationSystem.Core.Domain.UserEvaluationForms.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Infra.DAL.SQL.UserEvaluationForms.Repositories
{
    public class EfUserEvaluationFormRepository : IUserEvaluationFormRepository
    {
        private readonly EvaluationSystemDbContext dbContext;

        public EfUserEvaluationFormRepository(EvaluationSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddUserEvaluationForm(UserEvaluationForm entity)
        {
            dbContext.UserEvaluationForms.Add(entity);
        }

        public UserEvaluationForm GetUserEvaluationForm(int userId, int formId)
        {
            return dbContext.UserEvaluationForms.AsNoTracking()
                .Include(x => x.FormDetails)
                .Where(x => x.UserId == userId && x.EvaluationFormId == formId)
                .FirstOrDefault();            
        }

        public UserEvaluationForm Load(int userId, int fromId)
        {
            return dbContext.UserEvaluationForms
                 .Include(x => x.FormDetails)
                 .Where(x => x.UserId == userId && x.EvaluationFormId == fromId)
                 .FirstOrDefault();
        }
    }
}
