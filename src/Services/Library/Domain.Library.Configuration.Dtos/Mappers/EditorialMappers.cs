using AutoMapper;
using Domain.Library.Configuration.Dtos.Input;
using Domain.Library.Configuration.Dtos.Output;
using Domain.Library.Editorials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Library.Configuration.Dtos.Mappers
{
    public class EditorialMapper : Profile
    {
        public EditorialMapper()
        {
            CreateMap<Editorial, EditorialOutput>();
            CreateMap<CreateEditorialInput, Editorial>();
        }
    }
}
