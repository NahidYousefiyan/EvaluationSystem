using EvaluationSystem.Core.Domain.EvaluationForms.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvaluationSystem.Infra.DAL.SQL.EvaluationForms.Configs
{
    public class EvaluationFormAnswerConfiguration : IEntityTypeConfiguration<EvaluationFormAnswer>
    {
        public void Configure(EntityTypeBuilder<EvaluationFormAnswer> builder)
        {
            builder.ToTable("Tbl_EvaluationFormAnswers");

            builder.Property(x => x.Text)
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(x => x.Index)
               .HasColumnName("OrderId");

            builder.HasOne(x => x.Question)
                .WithMany(x=>x.Answers)
                .HasForeignKey(x => x.QuestionId);
        }
    }
}
