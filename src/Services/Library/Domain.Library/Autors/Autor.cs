using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Library.Autors
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar(45)")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar(45)")]
        public string LastName { get; set; }
    }
}
