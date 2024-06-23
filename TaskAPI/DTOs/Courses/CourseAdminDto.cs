namespace TaskAPI.DTOs.Courses
{
    public class CourseAdminDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Instructor { get; set; }
        public string Category { get; set; }
        public string MainImage { get; set; }
    }
}
