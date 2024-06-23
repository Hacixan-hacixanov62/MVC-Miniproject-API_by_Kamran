using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskAPI.Models;

namespace TaskAPI.Helpers.EntityConfigurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m=>m.FullName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m=>m.Subject)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Message)
                .IsRequired();

            builder.Property(m => m.CreatedDate)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
