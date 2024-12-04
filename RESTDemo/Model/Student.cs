using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTDemo.Model
{
    [Table("student")]
    public class Student
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public decimal percentage { get; set; }
        [Required]
        public string? branch { get; set; }
    }
}
