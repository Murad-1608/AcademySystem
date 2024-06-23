using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models.StudentModels
{
    public class CreateStudentModel
    {
        [Required(ErrorMessage ="Tələbə adı boş keçilə bilməz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Tələbə soyadı boş keçilə bilməz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Qrup nömrəsi boş keçilə bilməz")]
        public string Group { get; set; }

        [Required(ErrorMessage = "İxtisas boş keçilə bilməz")]
        public string Specialty { get; set; }
        [Required(ErrorMessage = "Telefon nömrəsi boş keçilə bilməz")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Doğum tarixi boş keçilə bilməz")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Ünvan boş keçilə bilməz")]
        public string Address { get; set; }
    }
}
