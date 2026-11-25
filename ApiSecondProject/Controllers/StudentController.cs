using ApiSecondProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ApiSecondProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApiDbContext db;
        public StudentController(ApiDbContext context)
        {
            this.db = context;
        }
        [HttpPost]
        public ActionResult<Student> CreateStudent([FromBody] Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return Ok(student);
        }
        [HttpGet]
        public ActionResult<List<Student>> GetStudents()
        {
            var students = db.Students.ToList();
            if (students == null || students.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(students);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = db.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(student);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Student> DeleteStudent(int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                db.Students.Remove(student);
                db.SaveChanges();
                return Ok();
            }

        }
        [HttpPut("{id}")]
        public ActionResult<Student> UpdateStudent(int id,[FromBody] Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            db.Students.Update(student);
            db.SaveChanges();

            return Ok();

        }
    }
}
