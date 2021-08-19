using Application.Library.Interfaces;
using AutoMapper;
using Domain.Library.Books;
using Domain.Library.Configuration.Dtos.Input;
using Domain.Library.Configuration.Dtos.Output;
using Infrastructure.Library.Implementation.RepositoriesInterface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.Implementation.Books
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BookService> _logger;
        private readonly IMapper _mapper;
        public BookService(IUnitOfWork unitOfWork, ILogger<BookService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BookOutput> Create(CreateBookInput input)
        {
            var book = _mapper.Map<Book>(input);
            var result = await _unitOfWork.Book.Add(book);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<BookOutput>(result);
        }

        public async Task<IEnumerable<BookOutput>> GetAll()
        {
            var result = await _unitOfWork.Book.All();
            return _mapper.Map<IEnumerable<BookOutput>>(result);
        }

        public async Task<BookOutput> GetById(int id)
        {
            var result = await _unitOfWork.Book.GetById(id);
            return _mapper.Map<BookOutput>(result);
        }
    }
}
