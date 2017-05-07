using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Team.Models;
using Vidly_Team.ViewModel;
using Vidly_Team.ViewModels;

namespace Vidly_Team.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
           _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            var membershipTypes = _context.MembershipTypes.ToList();
            var customerViewModel = new CustomersListViewModel
            {
                Customers =customers
            };
            return View(customerViewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
          

            return View(customer); 
        }
        public ActionResult New()
        {
            
            var membershipTypes = _context.MembershipTypes.ToList();
            var customerView = new CustomerForViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",customerView);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var customerView = new CustomerForViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                
                return View("CustomerForm", customerView);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var dbCustomer = _context.Customers.Single(c => c.Id == customer.Id);
                dbCustomer.Name = customer.Name;
                dbCustomer.BirthDate = customer.BirthDate;
                dbCustomer.IsSubscribeToNewsletter = customer.IsSubscribeToNewsletter;
                dbCustomer.MembershipTypeId = customer.MembershipTypeId;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerForViewModel
            {
                Customer =  customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            
            return View("CustomerForm", viewModel);
        }
    }
}