using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskAPI.Models;

namespace TaskAPI.Helpers.EntityConfigurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(m => m.FullName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Address)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Description)
                .IsRequired();

            builder.Property(m => m.Profession)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Phone)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Image)
                .IsRequired();

            builder.Property(m => m.CreatedDate)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
