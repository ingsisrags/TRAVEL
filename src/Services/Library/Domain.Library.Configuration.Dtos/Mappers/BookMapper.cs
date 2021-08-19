using AutoMapper;
using Domain.Library.Books;
using Domain.Library.Configuration.Dtos.Input;
using Domain.Library.Configuration.Dtos.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Library.Configuration.Dtos.Mappers
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<Book, BookOutput>();
            CreateMap<CreateBookInput, Book>();
        }
    }
}