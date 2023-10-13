using MediatR;
using Persistence.Repositories;

namespace Application.Features.Cinema.Commands
{
    public class CreateCinemaCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string ContactInformation { get; set; }
    }

    public class CreateCinemaCommandHandler : IRequestHandler<CreateCinemaCommand, int>
    {
        private readonly ICinemaRepository _cinemaRepository;

        public CreateCinemaCommandHandler(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<int> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
        {
            var newCinema = new Domain.Entities.CinemaEntity
            {
                Name = request.Name,
                Location = request.Location,
                ContactInformation = request.ContactInformation
            };

            await _cinemaRepository.AddCinemaAsync(newCinema);

            return newCinema.Id;
        }
    }
}
