using Application.Features.Movie.Commands;
using Infrastructure.Persistence.Repositories;
using Moq;
using Xunit;

namespace Application.Tests.Features.Movie.Commands
{
    public class UpdateMovieCommandTests
    {
        [Fact]
        public async void Handle_ValidData_ShouldUpdateMovie()
        {

            var movieRepositoryMock = new Mock<IMovieRepository>();
            var command = new UpdateMovieCommand
            {
                MovieId = 1,
                Title = "Updated Movie",
                Genre = "Comedy",
                ReleaseYear = 2022
            };
            var handler = new UpdateMovieCommandHandler(movieRepositoryMock.Object);

            await handler.Handle(command, CancellationToken.None);

            movieRepositoryMock.Verify(x => x.UpdateMovieAsync(It.IsAny<Domain.Entities.MovieEntity>()), Times.Once);
        }

    }
}
