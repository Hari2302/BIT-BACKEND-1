using System.ComponentModel.DataAnnotations;

namespace FetchAPI.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string Type { get; set; }
        public decimal Salary { get; set; }

        public decimal Exp {  get; set; }
    }
}
