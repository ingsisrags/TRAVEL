using Domain.Library.Authors;
using Domain.Library.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Library.Inventory
{
    public class BookAuthor
    {
        public int AutorId { get; set; }
        public int BookISBN { get; set; }

        [ForeignKey("BookISBN")]
        public Book Book { get; set; }

        [ForeignKey("AutorId")]
        public Author Author { get; set; }
    }
}
