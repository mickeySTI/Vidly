using System;
using System.Collections.Generic;
using System.Linq;
//Import this to be able to utilize the Include()
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Web.Mvc.Html;

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


        public ActionResult New()
        {

            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer) {


            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }


        // GET: Customers

        public ViewResult Index()
        {
            //Old way of getting data. This was when the data was hard coded into the controller
            /*    var customers = GetCustomers();*/

                                     //This is the DbSet that is in the Identity Model.                       
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
                                              // The Include() is used for Eager Loading to be able to load related objects.

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }



        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {

                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };


            return View("CustomerForm", viewModel);
        }





    }
}