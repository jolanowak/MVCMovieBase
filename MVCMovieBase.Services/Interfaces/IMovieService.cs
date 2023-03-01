using MVCMovieBase.Common;
using MVCMovieBase.Infrasctructure.Entities;

namespace MVCMovieBase.Services.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();
        bool Create(MovieDTO newMovie);
        Movie GetMovieToUpdate(int id);
        bool Update(MovieDTO updatedMovie);
        bool Delete(int movieId);
    }
}
