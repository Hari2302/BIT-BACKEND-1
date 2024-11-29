using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace FetchAPI.Models
{

    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationFormModel
    {


     
        public string Name { get; set; }

        [Key]
        public string Email { get; set; }
        public string Message { get; set; }


        public string Resume { get; set; }
        public string Status { get; set; }

    }






}
