namespace TaskAPI.DTOs.Courses
{
    public class CourseDetailDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Instructor { get; set; }
        public int Rating { get; set; }
        public string CreatedDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int StudentCount { get; set; }
        public List<CourseImageDto> CourseImages { get; set; }
    }
}
