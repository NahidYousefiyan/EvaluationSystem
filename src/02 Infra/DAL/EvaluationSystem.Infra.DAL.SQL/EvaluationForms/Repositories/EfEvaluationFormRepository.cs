using EvaluationSystem.Core.Domain.EvaluationForms.Dtos;
using EvaluationSystem.Core.Domain.EvaluationForms.Entities;
using EvaluationSystem.Core.Domain.EvaluationForms.Repositories;
using EvaluationSystem.Core.Domain.Users.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Infra.DAL.SQL.EvaluationForms.Repositories
{
    public class EfEvaluationFormRepository : IEvaluationFormRepository
    {
        private readonly EvaluationSystemDbContext dbContext;

        public EfEvaluationFormRepository(EvaluationSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public EvaluationForm GetEvaluationFormById(int formId)
        {
            return dbContext.EvaluationForms.AsNoTracking()
                .Include(x => x.EvaluationIndex)
                .Include(x => x.Questions)
                .ThenInclude(x => x.Answers)
                .Where(x => x.Id == formId)
                .FirstOrDefault();           
        }

        public List<EvaluationForm> GetEvaluationFormList(UserGroup userGroup)
        {
            return dbContext.EvaluationForms
               .AsNoTracking()
               .Include(x => x.EvaluationIndex)
               .Where(x => x.UserGroup == userGroup)
               .ToList();
        }
    }
}
