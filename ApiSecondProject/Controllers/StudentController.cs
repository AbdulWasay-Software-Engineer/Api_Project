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
    }
}
