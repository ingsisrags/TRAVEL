using Application.Library.Interfaces.Authors;
using AutoMapper;
using Domain.Library.Authors;
using Domain.Library.Configuration.Dtos.Input;
using Domain.Library.Configuration.Dtos.Output;
using Infrastructure.Library.Implementation.RepositoriesInterface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.Implementation.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AuthorService> _logger;
        private readonly IMapper _mapper;
        public AuthorService(IUnitOfWork unitOfWork, ILogger<AuthorService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<AuthorOutput> Create(CreateAuthorInput input)
        {
            var author = _mapper.Map<Author>(input);
            var result = await _unitOfWork.Authors.Add(author);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<AuthorOutput>(result);
        }

        public async Task<IEnumerable<AuthorOutput>> GetAll()
        {
            var result = await _unitOfWork.Authors.All();
            return _mapper.Map<IEnumerable<AuthorOutput>>(result);
        }

        public async Task<AuthorOutput> GetById(int id)
        {
            var result = await _unitOfWork.Authors.GetById(id);
            return _mapper.Map<AuthorOutput>(result);
        }
    }
}
