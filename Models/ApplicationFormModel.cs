using System.ComponentModel.DataAnnotations;

namespace FetchAPI.Models
{
    public class ApplicationFormModel
    {

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
   
        public string Email { get; set; }
        public string Resume { get; set; }
        public string Message { get; set; }
    }

}
