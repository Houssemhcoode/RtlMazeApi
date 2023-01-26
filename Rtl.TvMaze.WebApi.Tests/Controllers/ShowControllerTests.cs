using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Rtl.TvMaze.Implementation.Models;
using Rtl.TvMaze.Implementation.Services.Interfaces;
using Rtl.TvMaze.WebApi.Controllers;
using Xunit;

namespace Rtl.TvMaze.WebApi.Tests.Controllers
{
    public class ShowControllerTests
    {
        private readonly Mock<IShowService> _mockedShowService;
        private readonly Mock<ILogger<ShowController>> _mockedLogger;
        private readonly ShowController _sut;
        private readonly Fixture _fixture;

        public ShowControllerTests()
        {
            _mockedShowService = new Mock<IShowService>();
            _mockedLogger = new Mock<ILogger<ShowController>>();

            _sut = new ShowController(_mockedShowService.Object, _mockedLogger.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task Get_GetAllShowsFromDatabase_WithoutIssues()
        {
            // Arrange
            var results = _fixture.CreateMany<Show>();

            _mockedShowService
                .Setup(m => m.GetAllShows())
                .ReturnsAsync(results);

            // Act
            var actual = await _sut.Get();

            // Assert
            actual.Count().Should().Be(results.Count());
        }
    }
}
