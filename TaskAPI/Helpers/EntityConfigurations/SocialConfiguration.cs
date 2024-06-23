using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskAPI.Models;

namespace TaskAPI.Helpers.EntityConfigurations
{
    public class SocialConfiguration : IEntityTypeConfiguration<Social>
    {
        public void Configure(EntityTypeBuilder<Social> builder)
        {
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Icon)
                .IsRequired();

            builder.Property(m => m.CreatedDate)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
