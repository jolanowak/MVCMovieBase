using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCMovieBase.Infrasctructure.Entities;
using Newtonsoft.Json;

namespace MVCMovieBase.Infrasctructure.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {

        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).UseIdentityColumn();

            builder.Property(m => m.ScoreAverage).IsRequired(false);
            builder.Property(m => m.ScoreVotesCount).IsRequired(false);

            builder.HasData(SeedLargeData());

            builder.ToTable("Movie");
        }

        public List<Movie> SeedLargeData()
        {
            var movies = new List<Movie>();
            

            var moviesJsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InitialData", "movies-mock-data.json");
            using (StreamReader streamReader = new StreamReader(moviesJsonPath))
            {
                string json = streamReader.ReadToEnd();
                movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }

            return movies;
        }
    }
}
