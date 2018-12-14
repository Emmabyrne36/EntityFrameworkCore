using System.Collections.Generic;
using System.Linq;
using CoreEF.Models;
using Newtonsoft.Json;

namespace CoreEF.Data
{
    public class Seed
    {
        private readonly SchoolContext _context;
        public Seed(SchoolContext context)
        {
            _context = context;
        }

        public string SeedUsers()
        {
            // Only seed db if there are no users
            if (!_context.Students.Any() && !_context.Courses.Any())
            {
                var schoolData = System.IO.File.ReadAllText("Data/StudentsSeedData.json");
                var courseData = System.IO.File.ReadAllText("Data/CoursesSeedData.json");

                var students = JsonConvert.DeserializeObject<List<Student>>(schoolData);
                var courses = JsonConvert.DeserializeObject<List<Course>>(courseData);

                foreach (var student in students)
                {
                    _context.Students.Add(student);
                }

                foreach (var course in courses)
                {
                    _context.Courses.Add(course);
                }

                _context.SaveChanges();

                return "Data successfully seeded";
            }

            return "Data already in database";
        }
    }
}