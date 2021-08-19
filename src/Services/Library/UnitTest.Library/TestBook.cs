using Application.Library.Interfaces;
using DistributedServices.Library.Controllers;
using Domain.Library.Configuration.Dtos.Input;
using Domain.Library.Configuration.Dtos.Output;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace UnitTest.Library
{
    public class TestBook
    {
        readonly Mock<IBookService> mock = new Mock<IBookService>();
        readonly CreateBookInput bookin = new CreateBookInput()
        {
            Authors = new System.Collections.Generic.List<int>() { 1 },
            EditorialId = 1,
            Pages = 20,
            Synopsis = "Excelent",
            Tittle = "The book"
        };

        readonly CreateBookInput bookinLongTittle = new CreateBookInput()
        {
            Authors = new System.Collections.Generic.List<int>() { 1 },
            EditorialId = 1,
            Pages = 20,
            Synopsis = "Excelent",
            Tittle = "The bookkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk"
        };

        readonly BookOutput bookout = new BookOutput()
        {
            Authors = new System.Collections.Generic.List<AuthorOutput>() {
                    new AuthorOutput(){ Id=1, Name="Gabriel Garcia Marquez"}
                },
            Editorial = new EditorialOutput() { Id = 1, Campus = "Madrid", Name = "Universal" },
            Pages = 20,
            Synopsis = "Excelent",
            Tittle = "The book",

        };
        [SetUp]
        public void Setup()
        {
            mock.Setup(x => x.Create(bookin)).ReturnsAsync(bookout);

        }

        [Test]
        public async Task InsertBook()
        {
            BookController book = new BookController(mock.Object);
            var result = await book.Post(bookin);
            Assert.True(result.Equals(bookout));
        }

        [Test]
        public async Task ValidateLongForName()
        {
            BookController editorial = new BookController(mock.Object);
            var result = await editorial.Post(bookinLongTittle);
            Assert.Null(result);
        }
    }
}