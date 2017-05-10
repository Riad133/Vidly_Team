using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly_Team.Models;

namespace Vidly_Team.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        //Get /api/customers
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        //Get /api/customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {

                throw  new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customer;
        }
        //Post /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw  new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;

        }
        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerIndb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerIndb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            customerIndb.Name = customer.Name;
            customerIndb.BirthDate = customer.BirthDate;
            customerIndb.IsSubscribeToNewsletter = customer.IsSubscribeToNewsletter;
            customerIndb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
        }
        //Delete /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerIndb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerIndb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Customers.Remove(customerIndb);
            _context.SaveChanges();
        }
    }
}
