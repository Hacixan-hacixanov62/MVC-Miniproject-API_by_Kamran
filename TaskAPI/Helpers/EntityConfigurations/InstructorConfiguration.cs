using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskAPI.Models;

namespace TaskAPI.Helpers.EntityConfigurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
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

            builder.Property(m => m.Field)
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
