using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidPaynes.Models;
using VidPaynes.ViewModels;


namespace VidPaynes.Controllers
{

    [AllowAnonymous]
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Get Movie

        [Route("movies/list")]
        public ActionResult Movies()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            return View();

            return View();
        }

        [Route("movies/list/details/{Id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult MovieForm()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel()
            {
                Movie = new Movie(),
                Genres = genres
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.DateReleased = movie.DateReleased;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Stock = movie.Stock;
            }

            _context.SaveChanges();

            return RedirectToAction("Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);

        }

        // GET: Movie/Random
      //public ActionResult Random()
      //{
      //      var movie = new Movie() { Name = "Shrek" };

      //    var custom = new List<Customers>
      //     {
      //          new Customers {Name = "Customer 1"},
      //          new Customers {Name = "Customer 2"}
      //     };

      //      var viewModel = new RandomMovieViewModel() { Movie = movie, Customers = custom };

      //     return View(viewModel);
      //  }

      //  [Route("movies/released/{year:regex(\\d{4}):range(1900, 2020)}/{month:regex(\\d{2}):range(1,12)}")]
      //  public ActionResult ByReleaseDate(int year, int month)
      //  {
      //      return Content(year + "/" + month);
      //  }
    }
}