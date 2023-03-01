using MVCMovieBase.Common;
using MVCMovieBase.Infrasctructure;
using MVCMovieBase.Infrasctructure.Entities;
using MVCMovieBase.Services.Interfaces;

namespace MVCMovieBase.Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _movieDbContext;

        public MovieService(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _movieDbContext
                .Movie
                .AsEnumerable();
        }

        public bool Create(MovieDTO newMovie)
        {
            var dbMovie = new Movie()
            {
                Year = newMovie.Year,
                Country = newMovie.Country,
                Director = newMovie.Director,
                Genre = newMovie.Genre,
                Title = newMovie.Title,
                ScoreAverage = newMovie.ScoreAverage,
                ScoreVotesCount = newMovie.ScoreVotesCount
            };

            _movieDbContext.Movie.Add(dbMovie);
            var insertedCount = _movieDbContext.SaveChanges();

            if(insertedCount < 1)
            {
                return false;
            }

            return true;
        }

        public Movie GetMovieToUpdate(int id)
        {
            return _movieDbContext.Movie.Find(id);
        }

        public bool Update(MovieDTO updatedMovie)
        {
            var dbMovie = _movieDbContext.Movie.Find(updatedMovie.Id);

            if(dbMovie == null)
            {
                return false;
            }

            dbMovie.Year = updatedMovie.Year;
            dbMovie.Country = updatedMovie.Country;
            dbMovie.Director = updatedMovie.Director;
            dbMovie.Genre = updatedMovie.Genre;
            dbMovie.Title = updatedMovie.Title;
            dbMovie.ScoreVotesCount = updatedMovie.ScoreVotesCount;

            _movieDbContext.Movie.Update(dbMovie);
            var updatedCount = _movieDbContext.SaveChanges();

            if (updatedCount < 1)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int movieId)
        {
            var movie = _movieDbContext.Movie.Find(movieId);

            if(movie == null)
            {
                return false;
            }

            _movieDbContext.Movie.Remove(movie);
            var deletedCount = _movieDbContext.SaveChanges();

            if (deletedCount < 1)
            {
                return false;
            }

            return true;
        }
    }
}
