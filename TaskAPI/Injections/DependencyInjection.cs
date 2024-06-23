using FluentValidation;
using FluentValidation.AspNetCore;
using TaskAPI.DTOs.Abouts;
using TaskAPI.DTOs.Categories;
using TaskAPI.DTOs.Contacts;
using TaskAPI.DTOs.Courses;
using TaskAPI.DTOs.Informations;
using TaskAPI.DTOs.Instructors;
using TaskAPI.DTOs.Settings;
using TaskAPI.DTOs.Sliders;
using TaskAPI.DTOs.Socials;
using TaskAPI.DTOs.Students;
using TaskAPI.Services;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Injections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });

            services.AddScoped<IValidator<SliderCreateDto>, SliderCreateDtoValidator>();
            services.AddScoped<IValidator<SliderEditDto>, SliderEditDtoValidator>();
            services.AddScoped<ISliderService, SliderService>();

            services.AddScoped<IValidator<AboutCreateDto>, AboutCreateDtoValidator>();
            services.AddScoped<IValidator<AboutEditDto>, AboutEditDtoValidator>();
            services.AddScoped<IAboutService, AboutService>();

            services.AddScoped<IValidator<CategoryCreateDto>, CategoryCreateDtoValidator>();
            services.AddScoped<IValidator<CategoryEditDto>, CategoryEditDtoValidator>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IValidator<InstructorCreateDto>, InstructorCreateDtoValidator>();
            services.AddScoped<IValidator<InstructorEditDto>, InstructorEditDtoValidator>();
            services.AddScoped<IInstructorService, InstructorService>();

            services.AddScoped<IValidator<SocialCreateDto>, SocialCreateDtoValidator>();
            services.AddScoped<IValidator<SocialEditDto>, SocialEditDtoValidator>();
            services.AddScoped<ISocialService, SocialService>();

            services.AddScoped<IValidator<CourseCreateDto>, CourseCreateDtoValidator>();
            services.AddScoped<IValidator<CourseEditDto>, CourseEditDtoValidator>();
            services.AddScoped<ICourseService, CourseService>();

            services.AddScoped<IValidator<StudentCreateDto>, StudentCreateDtoValidator>();
            services.AddScoped<IValidator<StudentEditDto>, StudentEditDtoValidator>();
            services.AddScoped<IStudentService, StudentService>();

            services.AddScoped<IValidator<InformationCreateDto>, InformationCreateDtoValidator>();
            services.AddScoped<IValidator<InformationEditDto>, InformationEditDtoValidator>();
            services.AddScoped<IInformationService, InformationService>();

            services.AddScoped<IValidator<ContactCreateDto>, ContactCreateDtoValidator>();
            services.AddScoped<IContactService, ContactService>();

            services.AddScoped<IValidator<SettingEditDto>, SettingEditDtoValidator>();
            services.AddScoped<ISettingService, SettingService>();

            return services;
        }
    }
}
