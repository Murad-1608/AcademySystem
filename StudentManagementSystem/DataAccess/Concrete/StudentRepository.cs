using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.DataAccess.Abstract;
using StudentManagementSystem.Entities;

namespace StudentManagementSystem.DataAccess.Concrete
{
    public class StudentRepository : EfRepositoryBase<Student, AppDbContext>, IStudentRepository
    {     
    }
}
