using Application.Library.Interfaces;
using DistributedServices.Library.Controllers;
using Domain.Library.Configuration.Dtos.Input;
using Domain.Library.Configuration.Dtos.Output;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace UnitTest.Library
{
    public class TestEditorial
    {
        readonly Mock<IEditorialService> mock = new Mock<IEditorialService>();
        readonly CreateEditorialInput editorialin = new CreateEditorialInput()
        {
            Name = "Universal",
            Campus = "Madrid"
        };
     

        readonly EditorialOutput editorialout = new EditorialOutput()
        {
            Id = 1,
            Campus = "Madrid",
            Name = "Universal"
        };

        [SetUp]
        public void Setup()
        {
            mock.Setup(x => x.Create(editorialin)).ReturnsAsync(editorialout);

        }
        [Test]
        public async Task InsertBook()
        {
            EditorialController editorial = new EditorialController(mock.Object);
            var result = await editorial.Post(editorialin);
            Assert.True(result.Equals(editorialout));
        }

       
    }
}