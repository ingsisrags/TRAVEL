using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Library.Editorial
{
  public  class Editorial
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar(45)")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar(45)")]
        public string Campus { get; set; }
    }
}
