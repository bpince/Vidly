using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            else
            {
                return View("ReadOnlyList");
            }
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

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int? Id)
        {
            var selectedMovie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);

            if(selectedMovie != null)
            {
                var viewModel = new MovieViewModel(selectedMovie)
                {
                    Genres = _context.Genres.ToList(),
                };

                return View("CreateEdit", viewModel);
            }
            else
            {
                return HttpNotFound();
            }
            
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var viewModel = new MovieViewModel()
            {
                Genres = _context.Genres.ToList()
            };

            return View("CreateEdit", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
            }

            if(movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);

                if(movieInDb != null)
                {
                    movieInDb.Name = movie.Name;
                    movieInDb.GenreId = movie.GenreId;
                    movieInDb.ReleaseDate = movie.ReleaseDate;
                    movieInDb.AvailableAmount = movie.AvailableAmount;
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}