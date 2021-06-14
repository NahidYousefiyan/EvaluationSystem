using EvaluationSystem.Core.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvaluationSystem.Infra.DAL.SQL.Users.Configs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Tbl_Users");

            builder.Property(x => x.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.NationCode)
                .IsUnicode(false)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.UserName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Password)
                .IsRequired();


            builder.Property(x => x.UserGroup)
                .HasColumnType("TinyInt");

            builder.HasIndex(x => x.NationCode)
                .HasDatabaseName("IX_NationCode");

            builder.HasIndex(x => x.UserName)
                .HasDatabaseName("IX_UserName");


            builder.HasOne(x => x.College)
                .WithMany()
                .HasForeignKey(x => x.CollegeId);
        }
    }
}
