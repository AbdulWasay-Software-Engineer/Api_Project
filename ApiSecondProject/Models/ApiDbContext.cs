using ApiSecondProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSecondProject.Models
{
       public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}









