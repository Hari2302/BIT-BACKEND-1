using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace FetchAPI.Models
{

    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationFormModel
    {

        [Key]
         public int ID { get; set; }
        public string Name { get; set; }


        public string Email { get; set; }


        public string Resume { get; set; }

        public string Status { get; set; }
        public string Role { get; set; }

       

    }






}
