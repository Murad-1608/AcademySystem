using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DataAccess.Abstract;
using StudentManagementSystem.Entities;
using StudentManagementSystem.Models.CourseModels;

namespace StudentManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentCourseRepository _studentCourseRepository;
        public CourseController(ICourseRepository courseRepository,
                                IStudentRepository studentRepository,
                                IStudentCourseRepository studentCourseRepository)
        {
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _studentCourseRepository = studentCourseRepository;
        }

        public IActionResult Index()
        {
            var courses = _courseRepository.GetAll();

            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCourseModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            Course course = new()
            {
                Name = model.Name,
                Clock = model.Clock,
                Description = model.Description
            };
            _courseRepository.Add(course);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var course = _courseRepository.Get(x => x.Id == id);

            _courseRepository.Delete(course);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var course = _courseRepository.Get(x => x.Id == id);

            UpdateCourseModel model = new()
            {
                Id = course.Id,
                Name = course.Name,
                Clock = course.Clock,
                Description = course.Description
            };

            return View(model);
        }


        [HttpGet]
        public IActionResult AddStudent(int id)
        {
            AddStudentCourseModel model = new()
            {
                CourseId = id,
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult AddStudent(AddStudentCourseModel model)
        {
            StudentCourse studentCourse = new()
            {
                StudentId = model.StudentId,
                CourseId = model.CourseId,
            };
            _studentCourseRepository.Add(studentCourse);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetStudent(int courseId)
        {
            var course = _studentCourseRepository.GetWithStudents(courseId);

            return View(course);
        }
    }
}
