using System.Linq;
using System.Web.Mvc;
using ValueVideo.Models;
using ValueVideo.ViewModels;

namespace ValueVideo.Controllers
{
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


        // GET: Movies
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult MovieForm(int? id)
        {

            var viewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };

            if (id != null)
                viewModel.Movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            ModelState["movie.Id"].Errors.Clear();
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);

            }

            if (movie.Id != 0)
            {
                
                var movieFromDatabase = _context.Movies.Single(m => m.Id == movie.Id);
                movieFromDatabase.GenreId = movie.GenreId;
                movieFromDatabase.Name = movie.Name;
                movieFromDatabase.NumberAvailable = movie.NumberAvailable;
                

            }
            else
            {
                _context.Movies.Add(movie);
               }

            _context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}