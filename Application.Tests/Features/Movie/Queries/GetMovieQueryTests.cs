using Application.Features.Movie.Queries;
using Infrastructure.Persistence.Repositories;
using Moq;
using Xunit;

namespace Application.Tests.Features.Movie.Queries
{
    public class GetMovieQueryTests
    {
        [Fact]
        public async void Handle_ValidData_ShouldReturnMovie()
        {

            var movieRepositoryMock = new Mock<IMovieRepository>();
            movieRepositoryMock.Setup(x => x.GetMovieByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new Domain.Entities.MovieEntity { Id = 1, Title = "Test Movie" });

            var query = new GetMovieQuery { MovieId = 1 };
            var handler = new GetMovieQueryHandler(movieRepositoryMock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Test Movie", result.Title);
        }
    }
}
