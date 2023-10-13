using Application.Features.Movie.Queries;
using Infrastructure.Persistence.Repositories;
using Moq;
using Xunit;

namespace Application.Tests.Features.Movie.Queries
{
    public class ListMoviesQueryTests
    {
        [Fact]
        public async void Handle_ValidData_ShouldReturnListOfMovies()
        {

            var movieRepositoryMock = new Mock<IMovieRepository>();
            movieRepositoryMock.Setup(x => x.GetMoviesAsync())
                .ReturnsAsync(new List<Domain.Entities.MovieEntity>
                {
                    new Domain.Entities.MovieEntity { Id = 1, Title = "Movie 1" },
                    new Domain.Entities.MovieEntity { Id = 2, Title = "Movie 2" }
                });

            var query = new ListMoviesQuery();
            var handler = new ListMoviesQueryHandler(movieRepositoryMock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Collection(result,
                item => Assert.Equal("Movie 1", item.Title),
                item => Assert.Equal("Movie 2", item.Title)
            );
        }
    }
}
