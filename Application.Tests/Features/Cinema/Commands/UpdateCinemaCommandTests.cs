using Application.Features.Cinema.Commands;
using Infrastructure.Persistence.Repositories;
using Moq;
using Xunit;

namespace Application.Tests.Features.Cinema.Commands
{
    public class UpdateCinemaCommandTests
    {
        [Fact]
        public async void Handle_ValidData_ShouldUpdateCinema()
        {

            var cinemaRepositoryMock = new Mock<ICinemaRepository>();
            var command = new UpdateCinemaCommand
            {
                CinemaId = 1,
                Name = "Updated Cinema",
                Location = "Updated Location",
                ContactInformation = "9876543210"
            };
            var handler = new UpdateCinemaCommandHandler(cinemaRepositoryMock.Object);

            await handler.Handle(command, CancellationToken.None);

            cinemaRepositoryMock.Verify(x => x.UpdateCinemaAsync(It.IsAny<Domain.Entities.CinemaEntity>()), Times.Once);
        }

    }
}
