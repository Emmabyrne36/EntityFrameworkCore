using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreEF.Models
{
    public class Grade
    {
        public int Id { get; set; }
        
        [Key]
        public string GradeName { get; set; }
        public IList<Student> Students { get; set; }
        // The list above creates a one-to-many relationship between Students and Grades
        // This allows us to add multiple Student entites to a Grade entity
    }
}