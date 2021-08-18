﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Library.Books
{
    public class Book
    {
        [Key]
        [Column(TypeName = "Int(10)")]
        public int ISBN { get; set; }

        [Column(TypeName = "Varchar(45)")]
        public string Tittle { get; set; }

        [Column(TypeName = "Varchar(45)")]
        public string Synopsis { get; set; }
        public int Pages { get; set; }
    }
}