using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if(String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            //get movie list from db.
            var viewModel = _context.Movies.Include(m => m.Genre).ToList();

            return View(viewModel);
            //return Content(String.Format("page index = {0}, sort by = {1}", pageIndex, sortBy));
        }

        public ActionResult Details(int? Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);
            if (movie != null)
            {
                return View(movie);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Edit(int? Id)
        {
            var selectedMovie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);

            if(selectedMovie != null)
            {
                return View("CreateEdit", selectedMovie);
            }
            else
            {
                return HttpNotFound();
            }
            
        }

        public ActionResult New()
        {
            var viewModel = new MovieViewModel()
            {
                Genres = _context.Genres.ToList()
            };

            return View("CreateEdit", viewModel);
        }

        //REDUNDANT CODE??

        //[Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}

        //// GET: Movie
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek!" };

        //    var customers = new List<Customer>
        //    {
        //        new Customer { Name = "Customer 1" },
        //        new Customer { Name = "Customer 2" }
        //    };

        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}

        //public ActionResult Edit(int id)
        //{
        //    return Content("id =" + id);
        //}
    }
}