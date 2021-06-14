using EvaluationSystem.Core.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvaluationSystem.Infra.DAL.SQL.Users.Configs
{
    public class UserAccessTokenConfiguration : IEntityTypeConfiguration<UserAccessToken>
    {
        public void Configure(EntityTypeBuilder<UserAccessToken> builder)
        {
            builder.ToTable("Tbl_UserAccessToken");

            builder.Property(x => x.Token)
                .HasMaxLength(100);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
