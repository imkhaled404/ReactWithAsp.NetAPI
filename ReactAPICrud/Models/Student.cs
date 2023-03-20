using System.ComponentModel.DataAnnotations;

namespace ReactAPICrud.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Course { get; set; }
    }
}
