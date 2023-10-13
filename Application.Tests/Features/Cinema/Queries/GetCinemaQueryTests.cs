using Application.Features.Cinema.Queries;
using Infrastructure.Persistence.Repositories;
using Moq;
using Xunit;

namespace Application.Tests.Features.Cinema.Queries
{
    public class GetCinemaQueryTests
    {
        [Fact]
        public async void Handle_ValidData_ShouldReturnCinema()
        {

            var cinemaRepositoryMock = new Mock<ICinemaRepository>();
            cinemaRepositoryMock.Setup(x => x.GetCinemaByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new Domain.Entities.CinemaEntity { Id = 1, Name = "Test Cinema" });

            var query = new GetCinemaQuery { CinemaId = 1 };
            var handler = new GetCinemaQueryHandler(cinemaRepositoryMock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Test Cinema", result.Name);
        }
    }
}
