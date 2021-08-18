using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Library.Autor
{
    public class Autor
    {
        [Column(TypeName = "Int(10)")]
        public int Id { get; set; }

        [Column(TypeName = "Varchar(45)")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar(45)")]
        public string LastName { get; set; }
    }
}
