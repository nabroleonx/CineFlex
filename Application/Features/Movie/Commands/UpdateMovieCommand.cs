using MediatR;
using Persistence.Repositories;

namespace Application.Features.Movie.Commands
{
    public class UpdateMovieCommand : IRequest
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
    }

    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
    {
        private readonly IMovieRepository _movieRepository;

        public UpdateMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movieEntity = await _movieRepository.GetMovieAsync(request.MovieId);

            if (movieEntity == null)
            {
                throw new Exception("Movie not found.");
            }

            movieEntity.Title = request.Title;
            movieEntity.Genre = request.Genre;
            movieEntity.ReleaseYear = request.ReleaseYear;

            await _movieRepository.UpdateMovieAsync(movieEntity);

            return Unit.Value;
        }
    }
}
