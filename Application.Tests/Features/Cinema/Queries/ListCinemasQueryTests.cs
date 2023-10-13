using Application.Features.Cinema.Queries;
using Infrastructure.Persistence.Repositories;
using Moq;
using Xunit;

namespace Application.Tests.Features.Cinema.Queries
{
    public class ListCinemasQueryTests
    {
        [Fact]
        public async void Handle_ValidData_ShouldReturnListOfCinemas()
        {

            var cinemaRepositoryMock = new Mock<ICinemaRepository>();
            cinemaRepositoryMock.Setup(x => x.GetCinemasAsync())
                .ReturnsAsync(new List<Domain.Entities.CinemaEntity>
                {
                    new Domain.Entities.CinemaEntity { Id = 1, Name = "Cinema 1" },
                    new Domain.Entities.CinemaEntity { Id = 2, Name = "Cinema 2" }
                });

            var query = new ListCinemasQuery();
            var handler = new ListCinemasQueryHandler(cinemaRepositoryMock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Collection(result,
                item => Assert.Equal("Cinema 1", item.Name),
                item => Assert.Equal("Cinema 2", item.Name)
            );
        }
    }
}
