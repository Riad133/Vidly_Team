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
    [EnableCorsAttribute("*", "*", "*")]
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
      
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //Get /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }

        public IEnumerable<CustomerDto> GetCustomers(string search)
        {
            var customers =
                _context.Customers.Where(c => c.Name.Contains(search)).Select(Mapper.Map<Customer, CustomerDto>);
                            
            return customers;
        }

        // Get /api/customers/1
        public CustomerDto GetCustomer(int id)
        {
            Customer customer;
            if (id > 0)
            {
                 customer = _context.Customers.SingleOrDefault(c => c.Id == id);
                if (customer == null)
                {

                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            else
            {
                 customer =new Customer
                               {
                                 
                                   IsSubscribeToNewsletter = true,
                                   
                               };
            }
            return Mapper.Map<Customer,CustomerDto>(customer);
        }
        // Post /api/customers
        [HttpPost]
        public CustomerDto CreateCustomer([FromBody]CustomerDto customerDto)
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
        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id,[FromBody] CustomerDto customerDto)
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
        // Delete /api/customers/1
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
