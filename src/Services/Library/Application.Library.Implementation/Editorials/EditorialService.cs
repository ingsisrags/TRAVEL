using Application.Library.Interfaces;
using AutoMapper;
using Domain.Library.Configuration.Dtos.Input;
using Domain.Library.Configuration.Dtos.Output;
using Domain.Library.Editorials;
using Infrastructure.Library.Implementation.RepositoriesInterface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.Implementation.Editorials
{
  public  class EditorialService : IEditorialService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EditorialService> _logger;
        private readonly IMapper _mapper;
        public EditorialService(IUnitOfWork unitOfWork, ILogger<EditorialService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<EditorialOutput> Create(CreateEditorialInput input)
        {
            var editorial = _mapper.Map<Editorial>(input);
            var result = await _unitOfWork.Editorial.Add(editorial);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<EditorialOutput>(result);
        }

        public async Task<IEnumerable<EditorialOutput>> GetAll()
        {
            var result = await _unitOfWork.Editorial.All();
            return _mapper.Map<IEnumerable<EditorialOutput>>(result);
        }

        public async Task<EditorialOutput> GetById(int id)
        {
            var result = await _unitOfWork.Book.GetById(id);
            return _mapper.Map<EditorialOutput>(result);
        }
    }
}
