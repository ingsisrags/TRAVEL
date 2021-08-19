using Application.Library.Interfaces;
using Application.Library.Interfaces.Authors;
using DistributedServices.Library.Controllers;
using Domain.Library.Authors;
using Domain.Library.Configuration.Dtos.Input;
using Domain.Library.Configuration.Dtos.Output;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace UnitTest.Library
{
    public class TestAuthor
    {
        readonly Mock<IAuthorService> mock = new Mock<IAuthorService>();
        readonly CreateAuthorInput  authorin = new CreateAuthorInput()
        {
            Name = "Gabriel",
            LastName ="Garcia Marquez"
        };

        AuthorOutput authorout = new AuthorOutput()
        {
            Id=1,
            Name = "Gabriel",
            LastName = "Garcia Marquez"

        };
        [SetUp]
        public void Setup()
        {
            mock.Setup(x => x.Create(authorin)).ReturnsAsync(authorout);
        }

        [Test]
        public async Task InsertAuthor()
        {
            var book = new AuthorController(mock.Object);
            var result = await book.Post(authorin);
            Assert.True(result.Equals(authorout));
        }
    }
}