using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.DataAccess.Abstract;
using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DataAccess.Concrete
{
    public class CourseRepository : EfRepositoryBase<Course, AppDbContext>, ICourseRepository
    {
    }
}

// MVC nece isleyir