using AutoMapper;
using Domain.Library.Authors;
using Domain.Library.Configuration.Dtos.Input;
using Domain.Library.Configuration.Dtos.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Library.Configuration.Dtos.Mappers
{
    public class AuthorMapper : Profile
    {
        public AuthorMapper()
        {
            CreateMap<Author, AuthorOutput>();
            CreateMap<CreateAuthorInput, Author>();
        }
    }
}
