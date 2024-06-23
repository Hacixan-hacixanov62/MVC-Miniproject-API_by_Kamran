namespace TaskAPI.DTOs.Instructors
{
    public class InstructorWithSocialsDto
    {
        public string FullName { get; set; }
        public string Field { get; set; }
        public string Image { get; set; }
        public IEnumerable<InstructorSocialDto> InstructorSocials { get; set; }
    }
}
