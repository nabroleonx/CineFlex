using AutoMapper;
using MediatR;
using Persistence.Repositories;

namespace Application.Features.Movie.Queries
{
    public class ListMoviesQuery : IRequest<List<MovieDto>>
    {
        public string SearchTitle { get; set; }
    }

    public class ListMoviesQueryHandler : IRequestHandler<ListMoviesQuery, List<MovieDto>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public ListMoviesQueryHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<List<MovieDto>> Handle(ListMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetMoviesAsync();

            if (!string.IsNullOrEmpty(request.SearchTitle))
            {
                movies = movies.Where(movie => movie.Title.Contains(request.SearchTitle, StringComparison.OrdinalIgnoreCase));
            }

            var movieDtos = _mapper.Map<List<MovieDto>>(movies);
            return movieDtos;
        }
    }
}
