using Domain.Entities;

namespace Infrastructure.Persistence.Repositories
{
    public interface IMovieRepository
    {
        Task<MovieEntity> GetMovieAsync(int movieId);
        Task<List<MovieEntity>> GetMoviesAsync();
        Task AddMovieAsync(MovieEntity movie);
        Task UpdateMovieAsync(MovieEntity movie);
        Task DeleteMovieAsync(MovieEntity movie);
    }
}
