using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Vidly_Team.Dtos;
using Vidly_Team.Models;

namespace Vidly_Team.Controllers.Api
{
    [EnableCorsAttribute("http://localhost:2241", "*", "*")]
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        //Get /api/customers
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }

        //Get /api/customers/1
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {

                throw  new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Customer,CustomerDto>(customer);
        }
        //Post /api/customers
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw  new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return customerDto;

        }
        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
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

            Mapper.Map(customerDto, customerIndb);

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
