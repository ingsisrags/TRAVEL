using Domain.Library.Editorials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Library.Books
{
    public class Book
    {
        [Key]
        public int ISBN { get; set; }

        [Column(TypeName = "Varchar(45)")]
        public string Tittle { get; set; }

        [Column(TypeName = "Varchar(45)")]
        public string Synopsis { get; set; }
        public int Pages { get; set; }
        public int EditorialId { get; set; }

        [ForeignKey("EditorialId")]
        public Editorial Editorial { get; set; }
    }
}
