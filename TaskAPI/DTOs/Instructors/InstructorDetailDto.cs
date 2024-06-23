namespace TaskAPI.DTOs.Instructors
{
    public class InstructorDetailDto
    {
        public string FullName { get; set; }
        public string Image { get; set; }
        public string Field { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public IEnumerable<InstructorSocialDto> InstructorSocials { get; set; }
        public ICollection<string> Courses { get; set; }
    }
}
