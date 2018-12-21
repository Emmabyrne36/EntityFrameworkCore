using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreEF.Models
{
    [Table("SchoolTable")]
    public class School
    {
        public string Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}