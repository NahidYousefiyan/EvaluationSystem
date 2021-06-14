using EvaluationSystem.Core.Domain.EvaluationForms.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvaluationSystem.Infra.DAL.SQL.EvaluationForms.Configs
{
    public class EvaluationFormConfiguration : IEntityTypeConfiguration<EvaluationForm>
    {
        public void Configure(EntityTypeBuilder<EvaluationForm> builder)
        {
            builder.ToTable("Tbl_EvaluationForms");

            builder.Property(x => x.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.UserGroup)
                .HasColumnType("TinyInt");

            builder.HasOne(x => x.EvaluationIndex)
                            .WithMany()
                            .HasForeignKey(x => x.EvaluationIndexId)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
