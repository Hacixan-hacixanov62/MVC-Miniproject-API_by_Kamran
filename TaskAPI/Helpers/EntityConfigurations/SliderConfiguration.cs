using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskAPI.Models;

namespace TaskAPI.Helpers.EntityConfigurations
{
    public class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(m => m.Image)
                .IsRequired();

            builder.Property(m => m.CreatedDate)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
