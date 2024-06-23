using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DataAccess.Abstract;
using StudentManagementSystem.Entities;
using StudentManagementSystem.Models.StudentModels;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            var students = _studentRepository.GetAll();

            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateStudentModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            Student student = new()
            {
                Address = model.Address,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                BirthDate = model.BirthDate,
                Group = model.Group,
                Specialty = model.Specialty,
                Surname = model.Surname,
            };
            _studentRepository.Add(student);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _studentRepository.Get(x => x.Id == id);

            _studentRepository.Delete(student);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var student = _studentRepository.Get(x => x.Id == id);

            UpdateStudentModel model = new()
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Group = student.Group,
                Specialty = student.Specialty,
                PhoneNumber = student.PhoneNumber,
                BirthDate = student.BirthDate,
                Address = student.Address,
            };
            return View(model);
        }
    }
}
