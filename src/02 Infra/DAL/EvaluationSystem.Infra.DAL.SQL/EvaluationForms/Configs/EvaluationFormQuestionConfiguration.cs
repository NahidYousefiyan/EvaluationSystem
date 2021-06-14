using EvaluationSystem.Core.Domain.EvaluationForms.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvaluationSystem.Infra.DAL.SQL.EvaluationForms.Configs
{
    public class EvaluationFormQuestionConfiguration : IEntityTypeConfiguration<EvaluationFormQuestion>
    {
        public void Configure(EntityTypeBuilder<EvaluationFormQuestion> builder)
        {
            builder.ToTable("Tbl_EvaluationFormQuestions");

            builder.Property(x => x.Text)
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(x => x.Index)
                .HasColumnName("OrderId");

            builder.HasOne(x => x.Form)
                .WithMany(x=>x.Questions)
                .HasForeignKey(x => x.FormId);
           
        }
    }
}
