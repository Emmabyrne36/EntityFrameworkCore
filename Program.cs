﻿using System;
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
                Console.WriteLine(CallSeedUsers(seed)); // seed the db

                Console.WriteLine("");
                // var allStudents = context.Students.Select(s => s.FirstName);
                // foreach (var s in allStudents)
                // {
                //     Console.WriteLine(s);
                // }

                // Console.WriteLine();

                var studentsAndGrades = context.Students
                                                .FromSql("Select * from Students")
                                                .Include(s => s.Grade)
                                                .OrderBy(s => s.Grade.GradeName)
                                                .ToList();
                foreach (var sg in studentsAndGrades)
                {
                    Console.WriteLine($"{sg.FirstName} {sg.LastName}. Grade: {sg.Grade.GradeName}");
                }

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
                    Console.WriteLine();
                    Console.WriteLine(gs.firstName + " " + gs.lastName + "with a grade of " + gs.gradeName);
                }

                var orderedStudents = from Student in context.Students
                                      join Grade in context.Grades
                                      on Student.GradeId equals Grade.Id
                                      where Grade.GradeName != "A"
                                      orderby Grade.GradeName descending
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

                foreach (var os in orderedStudents)
                {
                    Console.WriteLine(os.FirstName + " " + os.GradeName);
                }

                // var studentsWithSameName = context.Students
                //                                     .Where(s => s.Name == GetName())
                //                                     .ToList();

                // foreach (var s in studentsWithSameName)
                // {
                //     Console.WriteLine(s.Name);
                // }

                // Console.WriteLine(context.Students.Select(n => n.Name).ToList()[0]);
                // Console.ReadLine();

                string name = "David";
                var storedProc = context.Students.FromSql($"GetStudents {name}").ToList();
                Console.WriteLine(storedProc.First().FirstName);

                // Can also use
                var param = new SqlParameter("@FirstName", name);
                var storedProc2 = context.Students.FromSql("GetStudents @FirstName", param).ToList();
                Console.WriteLine(storedProc2.First().FirstName);

            }
        }

        public static string GetName()
        {
            return "Bill";
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
