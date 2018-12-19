using System;
using System.Data.SqlClient;
using System.Linq;
using CoreEF.Data;
using CoreEF.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                Seed seed = new Seed(context);
                Console.WriteLine(CallSeedUsers(seed)); // Seed the DB with the information

                // Get students with their grades
                var studentsAndGrades = context.Students
                                                .FromSql("Select * from Students")
                                                .Include(s => s.Grade)
                                                .OrderBy(s => s.Grade.GradeName)
                                                .ToList();
                foreach (var sg in studentsAndGrades)
                {
                    Console.WriteLine($"{sg.FirstName} {sg.LastName}. Grade: {sg.Grade.GradeName}");
                }

                // Get the students with a grade of A
                var goodStudents = from Student in context.Students
                                   join Grade in context.Grades
                                   on Student.GradeId equals Grade.Id
                                   where Grade.GradeName == "A"
                                   select new
                                   {
                                       firstName = Student.FirstName,
                                       lastName = Student.LastName,
                                       gradeName = Grade.GradeName
                                   };
                Console.WriteLine("\nThe best students are...");
                foreach (var gs in goodStudents)
                {
                    Console.WriteLine(gs.firstName + " " + gs.lastName + "with a grade of " + gs.gradeName);
                }

                // Order the students who do not have an A grade by their grade
                var orderedStudents = from Student in context.Students
                                      join Grade in context.Grades
                                      on Student.GradeId equals Grade.Id
                                      where Grade.GradeName != "A"
                                      orderby Grade.GradeName
                                      select new StudentGrade()
                                      {
                                          StudentId = Student.StudentId,
                                          FirstName = Student.FirstName,
                                          LastName = Student.LastName,
                                          DateOfBirth = Student.DateOfBirth,
                                          Height = Student.Height,
                                          Weight = Student.Weight,
                                          GradeId = Grade.Id,
                                          GradeName = Grade.GradeName
                                      };

                Console.WriteLine("\nThe other students from best to worst are:");
                foreach (var os in orderedStudents)
                {
                    Console.WriteLine(os.FirstName + " " + os.GradeName);
                }

                Console.WriteLine("\nOutput of the stored procedure:");
                // Execute a stored procedure
                string name = "David";
                var storedProc = context.Students.FromSql($"GetStudents {name}").ToList();
                Console.WriteLine(storedProc.First().FirstName);

                // Can also use
                var param = new SqlParameter("@FirstName", name);
                var storedProc2 = context.Students.FromSql("GetStudents @FirstName", param).ToList();
                Console.WriteLine(storedProc2.First().FirstName);


                // Get a list of all the students
                Console.WriteLine();
                var testStudent = context.Students.ToList();
                foreach (var ts in testStudent)
                {
                    Console.WriteLine(ts.FirstName + " " + ts.LastName);
                }

                var tallStudents = context.Students.Where(s => s.Height > 70).ToList();
                Console.WriteLine("\nThe tall students are:");
                foreach (var ts in tallStudents)
                {
                    Console.WriteLine(ts.FirstName);
                }
            }
        }

        public static string CallSeedUsers(Seed seed)
        {
            return seed.SeedUsers();
        }
    }

    public class StudentGrade
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        public int GradeId { get; set; }
        public string GradeName { get; set; }

    }
}
