using System.ComponentModel.DataAnnotations;

namespace FetchAPI.Models
{
    public class EmployeeData
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }
}
