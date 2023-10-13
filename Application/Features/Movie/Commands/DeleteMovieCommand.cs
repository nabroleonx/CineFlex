using MediatR;
using Persistence.Repositories;

namespace Application.Features.Movie.Commands
{
    public class DeleteMovieCommand : IRequest
    {
        public int MovieId { get; set; }
    }

    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
    {
        private readonly IMovieRepository _movieRepository;

        public DeleteMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movieEntity = await _movieRepository.GetMovieAsync(request.MovieId);

            if (movieEntity == null)
            {
                throw new Exception("Movie not found.");
            }

            await _movieRepository.DeleteMovieAsync(movieEntity);

            return Unit.Value;
        }
    }
}
