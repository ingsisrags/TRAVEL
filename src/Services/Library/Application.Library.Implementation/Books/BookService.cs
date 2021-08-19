using Application.Library.Interfaces;
using AutoMapper;
using Domain.Library.Authors;
using Domain.Library.Books;
using Domain.Library.Configuration.Dtos.Input;
using Domain.Library.Configuration.Dtos.Output;
using Domain.Library.Inventory;
using Infrastructure.Library.Implementation.RepositoriesInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Configuration.Exceptions;

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
            await validate(input);

            var book = _mapper.Map<Book>(input);
            var bookResult = await _unitOfWork.Book.Add(book);

            await _unitOfWork.CompleteAsync();

            foreach (var author in await _unitOfWork.Authors.GetAll().Where(y => input.Authors.Contains(y.Id)).ToListAsync())
            {
                var bookAuthor = _mapper.Map<BookAuthor>(new Tuple<Book, Author>(book, author));
                await _unitOfWork.BookAuthor.Add(bookAuthor);
            }

            await _unitOfWork.CompleteAsync();

            var output = _mapper.Map<BookOutput>(await _unitOfWork.Book.GetAll().Include(x => x.Editorial).FirstOrDefaultAsync(x => x.ISBN == bookResult.ISBN));
            output.Authors = _mapper.Map<List<AuthorOutput>>(await _unitOfWork.BookAuthor.GetAll().Where(x => x.BookISBN == output.ISBN).Select(x => x.Author).ToListAsync());

            return output;
        }

        private async Task validate(CreateBookInput input)
        {
            var existsEditorial = await _unitOfWork.Editorial.Find(x => x.Id == input.EditorialId);

            if (existsEditorial is null) throw new NotFoundException("The editorial not exists");

            var existAuthor = _unitOfWork.Authors.GetAll().Any(x => input.Authors.Contains(x.Id));

            if (!existAuthor) throw new NotFoundException("Some authors don't exists");
        }

        public async Task<IEnumerable<BookOutput>> GetAll()
        {
            var resultBook = _mapper.Map<IEnumerable<BookOutput>>(await _unitOfWork.Book.GetAll().Include(x => x.Editorial).ToListAsync());
            foreach (var book in resultBook)
            {
                book.Authors = _mapper.Map<List<AuthorOutput>>(await _unitOfWork.BookAuthor.GetAll().Where(x => x.BookISBN == book.ISBN).Select(x => x.Author).ToListAsync());
            }
            return resultBook;
        }

        public async Task<BookOutput> GetById(int id)
        {
            var result = await _unitOfWork.Book.GetById(id);
            return _mapper.Map<BookOutput>(result);
        }
    }
}
