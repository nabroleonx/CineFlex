using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MovieEntity> GetMovieAsync(int movieId)
        {
            return await _context.Movies.FindAsync(movieId);
        }

        public async Task<List<MovieEntity>> GetMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task AddMovieAsync(MovieEntity movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(MovieEntity movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(MovieEntity movie)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}
