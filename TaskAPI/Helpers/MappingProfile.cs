using AutoMapper;
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
using TaskAPI.Models;

namespace TaskAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Slider
            CreateMap<Slider, SliderDto>();
            CreateMap<Slider, SliderDetailDto>()
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM.dd.yyyy")));
            CreateMap<SliderCreateDto, Slider>();
            CreateMap<SliderEditDto, Slider>()
                .ForMember(d => d.Image, opt => opt.Condition(s => s.Image is not null));

            //About
            CreateMap<About, AboutDto>();
            CreateMap<About, AboutDetailDto>()
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM.dd.yyyy")));
            CreateMap<AboutCreateDto, About>();
            CreateMap<AboutEditDto, About>()
                .ForMember(d => d.Image, opt => opt.Condition(s => s.Image is not null));

            //Category
            CreateMap<Category, CategoryDto>()
                .ForMember(d => d.CourseCount, opt => opt.MapFrom(s => s.Courses.Count));
            CreateMap<Category, CategoryDetailDto>()
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM.dd.yyyy")))
                .ForMember(d => d.CourseCount, opt => opt.MapFrom(s => s.Courses.Count))
                .ForMember(d => d.Courses, opt => opt.MapFrom(s => s.Courses.Select(m => m.Name)));
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryEditDto, Category>()
                .ForMember(d => d.Image, opt => opt.Condition(s => s.Image is not null));

            //Instructor
            CreateMap<InstructorSocial, InstructorSocialDto>()
                .ForMember(d => d.Icon, opt => opt.MapFrom(s => s.Social.Icon));
            CreateMap<Instructor, InstructorWithSocialsDto>();
            CreateMap<Instructor, InstructorDetailDto>()
                .ForMember(d => d.Courses, opt => opt.MapFrom(s => s.Courses.Select(m => m.Name)));
            CreateMap<Instructor, InstructorDto>();
            CreateMap<InstructorCreateDto, Instructor>();
            CreateMap<InstructorEditDto, Instructor>()
                .ForMember(d => d.Image, opt => opt.Condition(s => s.Image is not null));
            CreateMap<InstructorSocialAddDto, InstructorSocial>();

            //Social
            CreateMap<Social, SocialDto>();
            CreateMap<SocialCreateDto, Social>();
            CreateMap<SocialEditDto, Social>();

            //Course
            CreateMap<Course, CourseDto>()
                .ForMember(d => d.MainImage, opt => opt.MapFrom(s => s.CourseImages.FirstOrDefault(m => m.IsMain).Name))
                .ForMember(d => d.Instructor, opt => opt.MapFrom(s => s.Instructor.FullName))
                .ForMember(d => d.Duration, opt => opt.MapFrom(s => Math.Ceiling((decimal)(s.EndDate - s.StartDate).Days / 31)))
                .ForMember(d => d.StudentCount, opt => opt.MapFrom(s => s.CourseStudents.Count));
            CreateMap<Course, CourseAdminDto>()
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category.Name))
                .ForMember(d => d.Instructor, opt => opt.MapFrom(s => s.Instructor.FullName))
                .ForMember(d => d.MainImage, opt => opt.MapFrom(s => s.CourseImages.FirstOrDefault(m => m.IsMain).Name));
            CreateMap<CourseImage, CourseImageDto>();
            CreateMap<Course, CourseDetailDto>()
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category.Name))
                .ForMember(d => d.Instructor, opt => opt.MapFrom(s => s.Instructor.FullName))
                .ForMember(d => d.StudentCount, opt => opt.MapFrom(s => s.CourseStudents.Count))
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM.dd.yyyy")))
                .ForMember(d => d.StartDate, opt => opt.MapFrom(s => s.StartDate.ToString("MM.dd.yyyy")))
                .ForMember(d => d.EndDate, opt => opt.MapFrom(s => s.EndDate.ToString("MM.dd.yyyy")));
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseEditDto, Course>()
                .ForMember(d => d.CourseImages, opt => opt.Condition(s => s.CourseImages is not null));

            //Student
            CreateMap<Student, StudentDto>();
            CreateMap<Student, StudentDetailDto>()
                .ForMember(d => d.Courses, opt => opt.MapFrom(s => s.CourseStudents.Select(m => m.Course.Name)))
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM.dd.yyyy")));
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentEditDto, Student>()
                .ForMember(d => d.Image, opt => opt.Condition(s => s.Image is not null));
            CreateMap<CourseStudentAddDto, CourseStudent>();

            //Information
            CreateMap<Information, InformationDto>();
            CreateMap<Information, InformationDetailDto>()
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate.ToString("MM.dd.yyyy")));
            CreateMap<InformationCreateDto, Information>();
            CreateMap<InformationEditDto, Information>();

            //Contact
            CreateMap<Contact, ContactDto>();
            CreateMap<ContactCreateDto, Contact>();

            //Setting
            CreateMap<SettingEditDto, Setting>();
        }
    }
}
