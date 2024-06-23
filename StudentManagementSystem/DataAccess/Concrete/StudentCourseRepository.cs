using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.DataAccess.Abstract;
using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DataAccess.Concrete
{
    public class StudentCourseRepository : EfRepositoryBase<StudentCourse, AppDbContext>, IStudentCourseRepository
    {
        public List<StudentCourse> GetWithStudents(int courseId)
        {
            using (AppDbContext context = new())
            {
                return context.StudentCourses.Include(x => x.Student).Where(x => x.CourseId == courseId).Include(x => x.Course).ToList();
            }
        }
    }
}
