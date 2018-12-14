using CoreEF.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreEF
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Will create a database called TestSchoolDB
            optionsBuilder.UseSqlServer(@"Server=(local);Database=TestSchoolDB;Trusted_connection=True");
        }

    }
}