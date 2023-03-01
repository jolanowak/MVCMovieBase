using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCMovieBase.Common;
using MVCMovieBase.Services.Interfaces;
using MVCMovieBase.Web.Models;

namespace MVCMovieBase.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ISession session;

        public MovieController(IMovieService movieService, IHttpContextAccessor httpContextAccessor)
        {
            _movieService = movieService;
            session = httpContextAccessor.HttpContext.Session;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            var allDbMovies = _movieService.GetAll();

            var viewModel = new List<MovieViewModel>();
            foreach (var dbMovie in allDbMovies)
            {
                viewModel.Add(new MovieViewModel
                {
                    Id = dbMovie.Id,
                    Title = dbMovie.Title,
                    Country = dbMovie.Country,
                    Director = dbMovie.Director,
                    Genre = dbMovie.Genre,
                    Year = dbMovie.Year,
                    ScoreAverage = dbMovie.ScoreAverage,
                    ScoreVotesCount = dbMovie.ScoreVotesCount
                });
            }

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new MovieViewModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(MovieViewModel newMovie)
        {
            if (!ModelState.IsValid)
            {
                return View(newMovie);
            }

            var movieDto = new MovieDTO()
            {
                Year = newMovie.Year,
                Country = newMovie.Country,
                Director = newMovie.Director,
                Genre = newMovie.Genre,
                Title = newMovie.Title,
                ScoreAverage = newMovie.ScoreAverage,
                ScoreVotesCount = newMovie.ScoreVotesCount
            };

            var createdSuccessfully = _movieService.Create(movieDto);
            if (!createdSuccessfully)
            {
                return View(newMovie);
            }

            session.SetString("RecentlyAdded", newMovie.Title);

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var dbMovie = _movieService.GetMovieToUpdate(id);

            if(dbMovie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new MovieViewModel
            {
                Id = dbMovie.Id,
                Title = dbMovie.Title,
                Country = dbMovie.Country,
                Director = dbMovie.Director,
                Genre = dbMovie.Genre,
                Year = dbMovie.Year,
                ScoreAverage = dbMovie.ScoreAverage,
                ScoreVotesCount = dbMovie.ScoreVotesCount
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(MovieViewModel updatedMovieViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedMovieViewModel);
            }

            var movieDto = new MovieDTO
            {
                Id = updatedMovieViewModel.Id,
                Title = updatedMovieViewModel.Title,
                Country = updatedMovieViewModel.Country,
                Director = updatedMovieViewModel.Director,
                Genre = updatedMovieViewModel.Genre,
                Year = updatedMovieViewModel.Year,
                ScoreAverage = updatedMovieViewModel.ScoreAverage,
                ScoreVotesCount = updatedMovieViewModel.ScoreVotesCount
            };

            var updateSuccessful = _movieService.Update(movieDto);

            if (!updateSuccessful)
            {
                return View(updatedMovieViewModel);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
