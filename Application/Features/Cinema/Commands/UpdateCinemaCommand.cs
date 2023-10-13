using MediatR;
using Persistence.Repositories;

namespace Application.Features.Cinema.Commands
{
    public class UpdateCinemaCommand : IRequest
    {
        public int CinemaId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ContactInformation { get; set; }
    }

    public class UpdateCinemaCommandHandler : IRequestHandler<UpdateCinemaCommand>
    {
        private readonly ICinemaRepository _cinemaRepository;

        public UpdateCinemaCommandHandler(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<Unit> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
        {
            var cinemaEntity = await _cinemaRepository.GetCinemaAsync(request.CinemaId);

            if (cinemaEntity == null)
            {
                throw new Exception("Cinema not found.");
            }

            cinemaEntity.Name = request.Name;
            cinemaEntity.Location = request.Location;
            cinemaEntity.ContactInformation = request.ContactInformation;

            await _cinemaRepository.UpdateCinemaAsync(cinemaEntity);

            return Unit.Value;
        }
    }
}
