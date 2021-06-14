using EvaluationSystem.Core.Domain.EvaluationIndexes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvaluationSystem.Infra.DAL.SQL.EvaluationIndexes.Configs
{
    public class EvaluationIndexConfiguration : IEntityTypeConfiguration<EvaluationIndex>
    {
        public void Configure(EntityTypeBuilder<EvaluationIndex> builder)
        {
            builder.ToTable("Tbl_EvaluationIndex");

            builder.Property(x => x.Title)
               .HasMaxLength(100)
               .IsRequired();

        }
    }
}
