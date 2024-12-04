using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTDemo.Model
{
    [Table("book")]
    public class Book
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? author { get; set; }
        [Required]
        public decimal price { get; set; }
    }
}
