using AutoMapper;
using MediatR;
using Persistence.Repositories;

namespace Application.Features.Cinema.Queries
{
    public class ListCinemasQuery : IRequest<List<CinemaDto>>
    {
        public string SearchName { get; set; }
    }

    public class ListCinemasQueryHandler : IRequestHandler<ListCinemasQuery, List<CinemaDto>>
    {
        private readonly ICinemaRepository _cinemaRepository;
        private readonly IMapper _mapper;

        public ListCinemasQueryHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }

        public async Task<List<CinemaDto>> Handle(ListCinemasQuery request, CancellationToken cancellationToken)
        {
            var cinemas = await _cinemaRepository.GetCinemasAsync();

            if (!string.IsNullOrEmpty(request.SearchName))
            {
                cinemas = cinemas.Where(cinema => cinema.Name.Contains(request.SearchName, StringComparison.OrdinalIgnoreCase));
            }

            var cinemaDtos = _mapper.Map<List<CinemaDto>>(cinemas);
            return cinemaDtos;
        }
    }
}
