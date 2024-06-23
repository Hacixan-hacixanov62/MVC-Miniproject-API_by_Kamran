namespace TaskAPI.DTOs.Categories
{
    public class CategoryDetailDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string CreatedDate { get; set; }
        public ICollection<string> Courses { get; set; }
        public int CourseCount { get; set; }
    }
}
