using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskAPI.Models;

namespace TaskAPI.Helpers.EntityConfigurations
{
    public class CourseImageConfiguration : IEntityTypeConfiguration<CourseImage>
    {
        public void Configure(EntityTypeBuilder<CourseImage> builder)
        {
            builder.Property(m => m.Name)
                .IsRequired();
        }
    }
}
