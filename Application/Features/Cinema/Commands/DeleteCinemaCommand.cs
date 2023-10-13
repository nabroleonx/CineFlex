using MediatR;
using Persistence.Repositories;

namespace Application.Features.Cinema.Commands
{
    public class DeleteCinemaCommand : IRequest
    {
        public int CinemaId { get; set; }
    }

    public class DeleteCinemaCommandHandler : IRequestHandler<DeleteCinemaCommand>
    {
        private readonly ICinemaRepository _cinemaRepository;

        public DeleteCinemaCommandHandler(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<Unit> Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
        {
            var cinemaEntity = await _cinemaRepository.GetCinemaAsync(request.CinemaId);

            if (cinemaEntity == null)
            {
                throw new Exception("Cinema not found.");
            }

            await _cinemaRepository.DeleteCinemaAsync(cinemaEntity);

            return Unit.Value;
        }
    }
}
