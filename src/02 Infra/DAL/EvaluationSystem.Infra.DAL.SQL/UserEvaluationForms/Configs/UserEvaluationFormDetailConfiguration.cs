using EvaluationSystem.Core.Domain.UserEvaluationForms.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvaluationSystem.Infra.DAL.SQL.UserEvaluationForms.Configs
{
    public class UserEvaluationFormDetailConfiguration : IEntityTypeConfiguration<UserEvaluationFormDetail>
    {
        public void Configure(EntityTypeBuilder<UserEvaluationFormDetail> builder)
        {
            builder.ToTable("Tbl_UserEvaluationFormDetail");

            builder.HasOne(x => x.UserEvaluationForm)
                .WithMany(x=>x.FormDetails)
                .HasForeignKey(x => x.UserEvaluationFormId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
