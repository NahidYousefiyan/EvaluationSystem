using EvaluationSystem.Core.Domain.Common.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationSystem.Infra.DAL.SQL
{
    public class EvaluationSystemUnitOfWork: IUnitOfWork
    {
        private readonly EvaluationSystemDbContext dbContext;

        public EvaluationSystemUnitOfWork(EvaluationSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int Commit()
        {
            var entityForSave = GetEntityForSave();
            if (entityForSave != null && entityForSave.Count > 0)
                return dbContext.SaveChanges();
            return 0;
        }

        private List<EntityEntry> GetEntityForSave()
        {
            return dbContext.ChangeTracker
              .Entries()
              .Where(x => x.State == EntityState.Modified || x.State == EntityState.Added || x.State == EntityState.Deleted)
              .ToList();
        }
    }
}
