using Domain.Library.Authors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Library.Configuration.Dtos.Input
{
    public class CreateBookInput
    {
        [Required]
        [MaxLength(45, ErrorMessage = "The title very long")]
        public string Tittle { get; set; }
        [Required]
        [MaxLength(45, ErrorMessage = "The synopsis is very long")]
        public string Synopsis { get; set; }
        public int Pages { get; set; }

        public int AutorId { get; set; }
        public int EditorialId { get; set; }
    }
}
