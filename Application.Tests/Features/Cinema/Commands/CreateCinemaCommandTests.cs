using Application.Features.Cinema.Commands;
using Infrastructure.Persistence.Repositories;
using Moq;
using Xunit;

namespace Application.Tests.Features.Cinema.Commands
{
    public class CreateCinemaCommandTests
    {
        [Fact]
        public async void Handle_ValidData_ShouldCreateCinema()
        {

            var cinemaRepositoryMock = new Mock<ICinemaRepository>();
            var command = new CreateCinemaCommand
            {
                Name = "Test Cinema",
                Location = "Test Location",
                ContactInformation = "1234567890"
            };
            var handler = new CreateCinemaCommandHandler(cinemaRepositoryMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("Test Cinema", result.Name);
            Assert.Equal("Test Location", result.Location);
            Assert.Equal("1234567890", result.ContactInformation);
            cinemaRepositoryMock.Verify(x => x.AddCinemaAsync(It.IsAny<Domain.Entities.CinemaEntity>()), Times.Once);
        }

    }
}
