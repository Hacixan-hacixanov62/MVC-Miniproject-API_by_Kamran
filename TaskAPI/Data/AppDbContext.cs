using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskAPI.Models;

namespace TaskAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<InstructorSocial> InstructorSocials { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseImage> CourseImages { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Setting> Settings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

             modelBuilder.Entity<Setting>().HasData(
                new Setting
                {
                    Id = 1,
                    Key = "Location",
                    Value = "123 Street, New York, USA",
                    CreatedDate = DateTime.Now,
                },
                new Setting
                {
                    Id = 2,
                    Key = "Phone",
                    Value = "+012 345 67890",
                    CreatedDate = DateTime.Now,
                },
                new Setting
                {
                    Id = 3,
                    Key = "Email",
                    Value = "info@example.com",
                    CreatedDate = DateTime.Now,
                },
                new Setting
                {
                    Id = 4,
                    Key = "Logo",
                    Value = "fa fa-book me-3",
                    CreatedDate = DateTime.Now,
                },
                new Setting
                {
                    Id = 5,
                    Key = "Twitter",
                    Value = "twitter.com",
                    CreatedDate = DateTime.Now,
                },
                new Setting
                {
                    Id = 6,
                    Key = "Facebook",
                    Value = "facebook.com",
                    CreatedDate = DateTime.Now,
                },
                new Setting
                {
                    Id = 7,
                    Key = "Youtube",
                    Value = "youtube.com",
                    CreatedDate = DateTime.Now,
                },
                new Setting
                {
                    Id = 8,
                    Key = "Linkedin",
                    Value = "linkedin.com",
                    CreatedDate = DateTime.Now,
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
