using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly ApplicationDbContext _context;

        public CinemaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CinemaEntity> GetCinemaAsync(int cinemaId)
        {
            return await _context.Cinemas.FindAsync(cinemaId);
        }

        public async Task<List<CinemaEntity>> GetCinemasAsync()
        {
            return await _context.Cinemas.ToListAsync();
        }

        public async Task AddCinemaAsync(CinemaEntity cinema)
        {
            _context.Cinemas.Add(cinema);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCinemaAsync(CinemaEntity cinema)
        {
            _context.Entry(cinema).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCinemaAsync(CinemaEntity cinema)
        {
            _context.Cinemas.Remove(cinema);
            await _context.SaveChangesAsync();
        }
    }
}
