using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {   
            var movie = new Movie() {Name = "Shrek!"};


            return View(movie);

            //another way to return view
            //return new ViewResult();
        }

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

        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year + "/" + month);
        }      
      

    }
}