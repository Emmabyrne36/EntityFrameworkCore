using System;
using System.Linq;
using CoreEF.Data;
using CoreEF.Models;

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
                var allStudents = context.Students.Select(s => s.FirstName);
                foreach (var s in allStudents)
                {
                    Console.WriteLine(s);
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
}
