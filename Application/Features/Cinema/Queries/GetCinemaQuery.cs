using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Repositories;

namespace Application.Features.Cinema.Queries
{
    public class GetCinemaQuery : IRequest<CinemaDto>
    {
        public int CinemaId { get; set; }
    }

    public class GetCinemaQueryHandler : IRequestHandler<GetCinemaQuery, CinemaDto>
    {
        private readonly ICinemaRepository _cinemaRepository;
        private readonly IMapper _mapper;

        public GetCinemaQueryHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }

        public async Task<CinemaDto> Handle(GetCinemaQuery request, CancellationToken cancellationToken)
        {
            var cinemaEntity = await _cinemaRepository.GetCinemaAsync(request.CinemaId);

            if (cinemaEntity == null)
            {
                throw new Exception("Cinema not found.");
            }

            var cinemaDto = _mapper.Map<CinemaDto>(cinemaEntity);
            return cinemaDto;
        }
    }
}
