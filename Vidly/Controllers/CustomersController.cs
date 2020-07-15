using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Vidly.Models;
using Vidly.ViewModels;
namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        // This is to access the database
        private ApplicationDbContext _context;


        //Initializing database
        public CustomersController()
        {                  
            _context = new ApplicationDbContext();
        }


        //DbContext is a disposible object, so we need to properly dispose this object
        protected override void Dispose(bool disposing)
        {
            _context.Dispose(); 
        }


        // GET: Customers


        public ViewResult Index()
        {
            //Old way of getting data. This was when the data was hard coded into the controller
            /*    var customers = GetCustomers();*/

                                     //This is the DbSet that is in the Identity Model.                       
            var customers = _context.Customers.ToList();


            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

  

    }
}