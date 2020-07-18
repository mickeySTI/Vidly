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

            if(movie == null)
                return HttpNotFound();

            return View(movie);
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



        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

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













    }
}