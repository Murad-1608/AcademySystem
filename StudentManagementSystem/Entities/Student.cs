namespace StudentManagementSystem.Entities
{
    public sealed class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Group { get; set; }
        public string Specialty { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }

        public List<Course> Courses { get; set; }
    }
}


