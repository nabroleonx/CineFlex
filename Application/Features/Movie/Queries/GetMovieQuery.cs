using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Repositories;

namespace Application.Features.Movie.Queries
{
    public class GetMovieQuery : IRequest<MovieDto>
    {
        public int MovieId { get; set; }
    }

    public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, MovieDto>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetMovieQueryHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieDto> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var movieEntity = await _movieRepository.GetMovieAsync(request.MovieId);

            if (movieEntity == null)
            {
                throw new Exception("Movie not found.");
            }

            var movieDto = _mapper.Map<MovieDto>(movieEntity);
            return movieDto;
        }
    }
}
