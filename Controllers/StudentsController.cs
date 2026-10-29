using Microsoft.AspNetCore.Mvc;

namespace demoforapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static readonly List<Student> Students = new()
        {
            new Student
            {
                Id = 1,
                Name = "John",
                Age = 20,
                Course = "Computer Science"
            },
            new Student
            {
                Id = 2,
                Name = "Sarah",
                Age = 21,
                Course = "Information Technology"
            },
            new Student
            {
                Id = 3,
                Name = "David",
                Age = 19,
                Course = "Software Engineering"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(Students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            Student? student = Students.FirstOrDefault(student => student.Id == id);

            if (student is null)
            {
                return NotFound($"Student with ID {id} was not found.");
            }

            return Ok(student);
        }
    }
}