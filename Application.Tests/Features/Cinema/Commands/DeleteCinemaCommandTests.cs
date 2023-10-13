using Application.Features.Cinema.Commands;
using Infrastructure.Persistence.Repositories;
using Moq;
using Xunit;

namespace Application.Tests.Features/Cinema/Commands
{
    public class DeleteCinemaCommandTests
{
    [Fact]
    public async void Handle_ValidData_ShouldDeleteCinema()
    {

        var cinemaRepositoryMock = new Mock<ICinemaRepository>();
        var command = new DeleteCinemaCommand
        {
            CinemaId = 1
        };
        var handler = new DeleteCinemaCommandHandler(cinemaRepositoryMock.Object);

        await handler.Handle(command, CancellationToken.None);

        cinemaRepositoryMock.Verify(x => x.DeleteCinemaAsync(It.IsAny<Domain.Entities.CinemaEntity>()), Times.Once);
    }

}
}
