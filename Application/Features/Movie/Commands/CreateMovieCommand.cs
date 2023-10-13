using MediatR;
using Persistence.Repositories;

namespace Application.Features.Movie.Commands
{
    public class CreateMovieCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
    }

    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
    {
        private readonly IMovieRepository _movieRepository;

        public CreateMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var newMovie = new Domain.Entities.MovieEntity
            {
                Title = request.Title,
                Genre = request.Genre,
                ReleaseYear = request.ReleaseYear
            };

            await _movieRepository.AddMovieAsync(newMovie);

            return newMovie.Id;
        }
    }
}
