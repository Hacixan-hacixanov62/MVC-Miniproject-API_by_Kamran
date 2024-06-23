using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskAPI.Models;

namespace TaskAPI.Helpers.EntityConfigurations
{
    public class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Image)
                .IsRequired();

            builder.Property(m => m.CreatedDate)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
