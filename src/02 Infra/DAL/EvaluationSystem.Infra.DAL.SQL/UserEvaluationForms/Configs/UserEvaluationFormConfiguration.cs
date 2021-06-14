using EvaluationSystem.Core.Domain.UserEvaluationForms.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvaluationSystem.Infra.DAL.SQL.UserEvaluationForms.Configs
{
    public class UserEvaluationFormConfiguration : IEntityTypeConfiguration<UserEvaluationForm>
    {
        public void Configure(EntityTypeBuilder<UserEvaluationForm> builder)
        {
            builder.ToTable("Tbl_UserEvaluationForm");

            builder.HasOne(x => x.EvaluationForm)
                .WithMany()
                .HasForeignKey(x => x.EvaluationFormId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.UserId)
                .HasDatabaseName("IX_UserId");


            builder.HasIndex(x => x.EvaluationFormId)
               .HasDatabaseName("IX_FormId");
        }
    }
}
