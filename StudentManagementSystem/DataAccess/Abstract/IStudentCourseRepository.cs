using StudentManagementSystem.DataAccess.Concrete;
using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DataAccess.Abstract
{
    public interface IStudentCourseRepository : IRepositoryBase<StudentCourse>
    {
        List<StudentCourse> GetWithStudents(int courseId);
    }
}
