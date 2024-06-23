namespace TaskAPI.DTOs.Courses
{
    public class CourseDto
    {
        public string Name { get; set; }
        public string MainImage { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public string Instructor { get; set; }
        public decimal Duration { get; set; }
        public int StudentCount { get; set; }
    }
}
