using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Library.Configuration.Dtos.Input
{
    public class CreateEditorialInput
    {
        [Required]
        [MaxLength(45, ErrorMessage = "The name is very long")]
        public string Name { get; set; }
        [Required]
        [MaxLength(45, ErrorMessage = "The campus is very long")]
        public string Campus { get; set; }
    }
}
