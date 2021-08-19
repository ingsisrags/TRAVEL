using AutoMapper;
using Domain.Library.Authors;
using Domain.Library.Books;
using Domain.Library.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Library.Configuration.Dtos.Mappers
{
    public class BookAuthorMapper : Profile
    {
        public BookAuthorMapper()
        {
            CreateMap<Tuple<Book,Author>, BookAuthor>()
                .ForMember(x=>x.AutorId, opt=>opt.MapFrom(y=>y.Item2.Id))
                .ForMember(x=>x.BookISBN, opt=>opt.MapFrom(y=>y.Item1.ISBN))
                ;
        }
    }
}
