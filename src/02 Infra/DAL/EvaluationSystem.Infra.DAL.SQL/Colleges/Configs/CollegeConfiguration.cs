using EvaluationSystem.Core.Domain.Colleges.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvaluationSystem.Infra.DAL.SQL.Colleges.Configs
{
    public class CollegeConfiguration : IEntityTypeConfiguration<College>
    {
        public void Configure(EntityTypeBuilder<College> builder)
        {
            builder.ToTable("Tbl_Colleges");

           
            builder.Property(x => x.CollegeName)
                .HasMaxLength(100)
                .IsRequired();

          
        }
    }
}
