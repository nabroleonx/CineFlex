using Application.Features.Movie.Commands;
using Infrastructure.Persistence.Repositories;
using Moq;
using Xunit;

namespace Application.Tests.Features.Movie.Commands
{
    public class CreateMovieCommandTests
    {
        [Fact]
        public async void Handle_ValidData_ShouldCreateMovie()
        {

            var movieRepositoryMock = new Mock<IMovieRepository>();
            var command = new CreateMovieCommand
            {
                Title = "Test Movie",
                Genre = "Action",
                ReleaseYear = 2023
            };
            var handler = new CreateMovieCommandHandler(movieRepositoryMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("Test Movie", result.Title);
            Assert.Equal("Action", result.Genre);
            Assert.Equal(2023, result.ReleaseYear);
            movieRepositoryMock.Verify(x => x.AddMovieAsync(It.IsAny<Domain.Entities.MovieEntity>()), Times.Once);
        }

    }
}
