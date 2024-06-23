namespace StudentManagementSystem.Entities
{
    public sealed class Course
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Clock { get; set; }
        public string Description { get; set; }

        public List<Student> Students { get; set; }
    }
}
