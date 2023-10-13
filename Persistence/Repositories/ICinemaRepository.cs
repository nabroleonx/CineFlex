using Domain.Entities;

namespace Infrastructure.Persistence.Repositories
{
    public interface ICinemaRepository
    {
        Task<CinemaEntity> GetCinemaAsync(int cinemaId);
        Task<List<CinemaEntity>> GetCinemasAsync();
        Task AddCinemaAsync(CinemaEntity cinema);
        Task UpdateCinemaAsync(CinemaEntity cinema);
        Task DeleteCinemaAsync(CinemaEntity cinema);
    }
}
