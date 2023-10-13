using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Seed
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Movies.Any() || context.Cinemas.Any())
                {
                    return;
                }

                context.Movies.AddRange(
                    new MovieEntity { Title = "Movie 1", Genre = "Action", ReleaseYear = 2023 },
                    new MovieEntity { Title = "Movie 2", Genre = "Comedy", ReleaseYear = 2022 },
                );

                context.Cinemas.AddRange(
                    new CinemaEntity { Name = "Cinema A", Location = "Location A", ContactInfo = "0909090909" },
                    new CinemaEntity { Name = "Cinema B", Location = "Location B", ContactInfo = "0707070707" },
                );

                context.SaveChanges();
            }
        }
    }
}
