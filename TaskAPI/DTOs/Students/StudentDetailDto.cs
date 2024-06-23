namespace TaskAPI.DTOs.Students
{
    public class StudentDetailDto
    {
        public string FullName { get; set; }
        public string Image { get; set; }
        public string Profession { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public ICollection<string> Courses { get; set; }
        public string CreatedDate { get; set; }
    }
}
