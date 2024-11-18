using System.ComponentModel.DataAnnotations;

namespace FetchAPI.Models
{
    public class Intern
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }    


    }
}
