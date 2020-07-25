using Microsoft.Ajax.Utilities;
using System;
//Import this to be able to utilize the Include()
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        /*[Route("Movies")]
        public ActionResult Index()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }


            };


            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers,
            };




            return View(viewModel);

            //another way to return view
            //return new ViewResult();
        }*/



        private ApplicationDbContext _context;


        //Initializing database
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        //DbContext is a disposible object, so we need to properly dispose this object
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        [Route("Movies")]
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }



        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }





        //Hard coded data
        /*   private IEnumerable<Movie> GetMovies()
           {
               return new List<Movie>
               {
                   new Movie { Id = 1, Name = "Shrek" },
                   new Movie { Id = 2, Name = "Wall-E" }
               };



           }
   */





        //movies
        // ? to make nullable
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)

                pageIndex = 1;


            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        }


        //Attribute routing
        [Route("movies/release/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year + "/" + month);
        }


        public ActionResult New()
        {
                
                var genres = _context.Genres.ToList();
                
            
                var viewModel = new MovieFormViewModel
                {
                   Genres = genres
                };

         
            return View("MovieForm", viewModel);
        }


        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInstock = movie.NumberInstock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }



    }
}