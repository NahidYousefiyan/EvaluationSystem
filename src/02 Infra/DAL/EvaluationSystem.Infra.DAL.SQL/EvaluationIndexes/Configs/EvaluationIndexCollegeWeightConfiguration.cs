using EvaluationSystem.Core.Domain.EvaluationIndexes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Infra.DAL.SQL.EvaluationIndexes.Configs
{
    public class EvaluationIndexCollegeWeightConfiguration : IEntityTypeConfiguration<EvaluationIndexCollegeWeight>
    {
        public void Configure(EntityTypeBuilder<EvaluationIndexCollegeWeight> builder)
        {
            builder.ToTable("Tbl_EvaluationIndexCollegeWeight");

            builder.HasKey(x => new { x.CollegeId, x.EvaluationIndexId });

            builder.HasOne(x => x.College)
                .WithMany()
                .HasForeignKey(x => x.CollegeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.EvaluationIndex)
                .WithMany()
                .HasForeignKey(x => x.EvaluationIndexId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
