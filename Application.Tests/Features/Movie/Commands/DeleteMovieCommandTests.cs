using Application.Features.Movie.Commands;
using Infrastructure.Persistence.Repositories;
using Moq;
using Xunit;

namespace Application.Tests.Features.Movie.Commands
{
    public class DeleteMovieCommandTests
    {
        [Fact]
        public async void Handle_ValidData_ShouldDeleteMovie()
        {

            var movieRepositoryMock = new Mock<IMovieRepository>();
            var command = new DeleteMovieCommand
            {
                MovieId = 1
            };
            var handler = new DeleteMovieCommandHandler(movieRepositoryMock.Object);

            await handler.Handle(command, CancellationToken.None);

            movieRepositoryMock.Verify(x => x.DeleteMovieAsync(It.IsAny<Domain.Entities.MovieEntity>()), Times.Once);
        }

    }
}
